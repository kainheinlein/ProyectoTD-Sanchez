using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    /// Ayuda en linea: arbol de temas a la izquierda y texto a la derecha. Ventana propia (no MDI) para que
    /// F1 no cierre la pantalla en uso y para poder cambiar de idioma con la ayuda abierta.
    public partial class frmAyuda_883SC : Form, IObservadorIdioma_883SC
    {
        AyudaBLL_883SC ayudaBLL_883SC = new AyudaBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private string _claveActual_883SC;
        private bool _cargandoArbol_883SC = false;
        private List<AyudaTemaBE_883SC> _temas_883SC = new List<AyudaTemaBE_883SC>();

        /// Clave del tema que se muestra (null si no hay temas)
        public string ClaveActual_883SC
        {
            get { return _claveActual_883SC; }
        }

        public frmAyuda_883SC(string claveTema)
        {
            InitializeComponent();
            _claveActual_883SC = claveTema;
        }

        private void frmAyuda_Load_883SC(object sender, EventArgs e)
        {
            //Suscribir llama a ActualizarTextos: ahi se carga el arbol
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmAyuda_FormClosed_883SC;
        }

        private void frmAyuda_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("AYUDA_TITULO");
            lblTitulo.Text = gestorIdioma_883SC.Traducir_883SC("AYUDA_LBL_TITULO");
            lblTemas.Text = gestorIdioma_883SC.Traducir_883SC("AYUDA_LBL_TEMAS");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            CargarTemas_883SC();
        }

        #endregion

        /// Muestra el tema pedido; si no existe, el de inicio y, si tampoco, el primero
        public void MostrarTema_883SC(string claveTema)
        {
            _claveActual_883SC = claveTema;
            SeleccionarTema_883SC(claveTema);
        }

        //Vuelve a leer los temas del idioma activo y deja seleccionado el mismo tema
        private void CargarTemas_883SC()
        {
            try
            {
                _temas_883SC = ayudaBLL_883SC.ListarTemas_883SC();
            }
            catch (Exception ex)
            {
                _temas_883SC = new List<AyudaTemaBE_883SC>();
                tvTemas.Nodes.Clear();
                rtbContenido.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message;
                return;
            }

            _cargandoArbol_883SC = true;
            tvTemas.BeginUpdate();
            tvTemas.Nodes.Clear();
            foreach (AyudaTemaBE_883SC tema in _temas_883SC)
            {
                TreeNode nodo = new TreeNode(tema.Titulo_883SC);
                nodo.Tag = tema.Clave_883SC;
                tvTemas.Nodes.Add(nodo);
            }
            tvTemas.EndUpdate();
            _cargandoArbol_883SC = false;

            if (_temas_883SC.Count == 0)
            {
                rtbContenido.Text = gestorIdioma_883SC.Traducir_883SC("AYUDA_MSG_SIN_TEMAS");
                return;
            }
            SeleccionarTema_883SC(_claveActual_883SC);
        }

        private void SeleccionarTema_883SC(string claveTema)
        {
            TreeNode nodo = BuscarNodo_883SC(claveTema) ?? BuscarNodo_883SC(AyudaBLL_883SC.TemaInicio_883SC);
            if (nodo == null && tvTemas.Nodes.Count > 0) { nodo = tvTemas.Nodes[0]; }
            if (nodo == null) { return; }

            if (tvTemas.SelectedNode == nodo)
            {
                //Ya estaba elegido (por ejemplo al cambiar de idioma): AfterSelect no se dispara, se redibuja a mano
                MostrarContenido_883SC((string)nodo.Tag);
            }
            else
            {
                tvTemas.SelectedNode = nodo;
            }
            nodo.EnsureVisible();
        }

        private TreeNode BuscarNodo_883SC(string claveTema)
        {
            if (string.IsNullOrEmpty(claveTema)) { return null; }
            foreach (TreeNode nodo in tvTemas.Nodes)
            {
                if ((string)nodo.Tag == claveTema) { return nodo; }
            }
            return null;
        }

        private void tvTemas_AfterSelect_883SC(object sender, TreeViewEventArgs e)
        {
            if (_cargandoArbol_883SC || e.Node == null) { return; }
            MostrarContenido_883SC((string)e.Node.Tag);
        }

        //Las lineas que empiezan con "== " son titulos de seccion (negrita); el resto es texto plano
        private void MostrarContenido_883SC(string claveTema)
        {
            AyudaTemaBE_883SC tema = _temas_883SC.Find(t => t.Clave_883SC == claveTema);
            if (tema == null) { return; }
            _claveActual_883SC = claveTema;

            Font normal = rtbContenido.Font;
            Font titulo = new Font(normal, FontStyle.Bold);
            Font encabezado = new Font(normal.FontFamily, normal.Size + 3, FontStyle.Bold);
            try
            {
                rtbContenido.SuspendLayout();
                rtbContenido.Clear();

                rtbContenido.SelectionFont = encabezado;
                rtbContenido.AppendText(tema.Titulo_883SC + "\n\n");

                foreach (string linea in tema.Contenido_883SC.Split('\n'))
                {
                    if (linea.StartsWith("== "))
                    {
                        rtbContenido.SelectionFont = titulo;
                        rtbContenido.SelectionColor = Color.Firebrick;
                        rtbContenido.AppendText(linea.Substring(3) + "\n");
                    }
                    else
                    {
                        rtbContenido.SelectionFont = normal;
                        rtbContenido.SelectionColor = rtbContenido.ForeColor;
                        rtbContenido.AppendText(linea + "\n");
                    }
                }
                rtbContenido.Select(0, 0);
                rtbContenido.ScrollToCaret();
            }
            finally
            {
                rtbContenido.ResumeLayout();
                titulo.Dispose();
                encabezado.Dispose();
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
