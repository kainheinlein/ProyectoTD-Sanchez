using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmIdiomas_883SC : Form, IObservadorIdioma_883SC
    {
        public frmIdiomas_883SC()
        {
            InitializeComponent();
        }

        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        DataTable traducciones_883SC;

        private void frmIdiomas_Load_883SC(object sender, EventArgs e)
        {
            CargarIdiomas_883SC();
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmIdiomas_FormClosed_883SC;
        }

        private void frmIdiomas_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("IDI_TITULO");
            gbNuevo.Text = gestorIdioma_883SC.Traducir_883SC("IDI_GB_NUEVO");
            lblCodigo.Text = gestorIdioma_883SC.Traducir_883SC("IDI_LBL_CODIGO");
            lblNombre.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_NOMBRE");
            lblBase.Text = gestorIdioma_883SC.Traducir_883SC("IDI_LBL_BASE");
            lblArchivo.Text = gestorIdioma_883SC.Traducir_883SC("IDI_LBL_ARCHIVO");
            btnExaminar.Text = gestorIdioma_883SC.Traducir_883SC("IDI_BTN_EXAMINAR");
            btnCrear.Text = gestorIdioma_883SC.Traducir_883SC("IDI_BTN_CREAR");
            gbTraducciones.Text = gestorIdioma_883SC.Traducir_883SC("IDI_GB_TRADUCCIONES");
            lblIdioma.Text = gestorIdioma_883SC.Traducir_883SC("IDI_LBL_IDIOMA");
            btnGuardar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_GUARDAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            TraducirColumnas_883SC();
        }

        private void TraducirColumnas_883SC()
        {
            if (dgvTraducciones.Columns.Count == 0) { return; }
            dgvTraducciones.Columns["Clave"].HeaderText = gestorIdioma_883SC.Traducir_883SC("IDI_COL_CLAVE");
            dgvTraducciones.Columns["Texto"].HeaderText = gestorIdioma_883SC.Traducir_883SC("IDI_COL_TEXTO");
        }

        #endregion

        private void CargarIdiomas_883SC()
        {
            cmbIdioma.DataSource = gestorIdioma_883SC.ObtenerIdiomas_883SC();
        }

        private void SeleccionarIdioma_883SC(string codigo)
        {
            //Deja seleccionado en el combo el idioma recien creado,
            //listo para editar sus traducciones en la grilla
            foreach (IdiomaBE_883SC idioma in (List<IdiomaBE_883SC>)cmbIdioma.DataSource)
            {
                if (idioma.Codigo_883SC == codigo)
                {
                    cmbIdioma.SelectedItem = idioma;
                    break;
                }
            }
        }

        private void cmbIdioma_SelectedIndexChanged_883SC(object sender, EventArgs e)
        {
            CargarTraducciones_883SC();
        }

        private void CargarTraducciones_883SC()
        {
            IdiomaBE_883SC idioma = cmbIdioma.SelectedItem as IdiomaBE_883SC;
            if (idioma == null) { return; }

            traducciones_883SC = gestorIdioma_883SC.ObtenerTablaTraducciones_883SC(idioma.Id_883SC);
            dgvTraducciones.DataSource = traducciones_883SC;
            dgvTraducciones.Columns["Clave"].ReadOnly = true;
            dgvTraducciones.Columns["Texto"].ReadOnly = false;
            TraducirColumnas_883SC();
        }

        private void btnExaminar_Click_883SC(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Archivos de traducciones (*.csv;*.txt)|*.csv;*.txt|Todos los archivos (*.*)|*.*";
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    txtArchivo.Text = dialogo.FileName;
                }
            }
        }

        private void btnCrear_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string codigo = txtCodigo.Text.Trim().ToUpper();
                string rutaArchivo = txtArchivo.Text.Trim() == "" ? null : txtArchivo.Text.Trim();

                int importadas = gestorIdioma_883SC.AgregarIdioma_883SC(codigo, nombre, rutaArchivo);
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC,
                    TipoAccion_883SC.AltaIdioma);

                if (importadas > 0)
                {
                    MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("IDI_MSG_IMPORTADAS"), nombre, importadas));
                }
                else
                {
                    MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("IDI_MSG_CREADO"), nombre));
                }
                txtCodigo.Clear();
                txtNombre.Clear();
                txtArchivo.Clear();
                CargarIdiomas_883SC();
                SeleccionarIdioma_883SC(codigo);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("IDI_ERR_ARCHIVO") + ex.Message);
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("IDI_ERR_ARCHIVO") + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
            }
        }

        private void btnGuardar_Click_883SC(object sender, EventArgs e)
        {
            IdiomaBE_883SC idioma = cmbIdioma.SelectedItem as IdiomaBE_883SC;
            if (idioma == null || traducciones_883SC == null) { return; }

            try
            {
                //Confirma la edicion pendiente de celda Y de fila antes de leer
                //los RowState, sino la fila en edicion no figura como Modified
                dgvTraducciones.EndEdit();
                this.Validate();
                this.BindingContext[traducciones_883SC].EndCurrentEdit();

                Dictionary<string, string> cambios = new Dictionary<string, string>();
                foreach (DataRow fila in traducciones_883SC.Rows)
                {
                    if (fila.RowState == DataRowState.Modified)
                    {
                        cambios[fila["Clave"].ToString()] = fila["Texto"].ToString();
                    }
                }
                if (cambios.Count == 0) { return; }

                gestorIdioma_883SC.GuardarTraducciones_883SC(idioma.Id_883SC, cambios);
                traducciones_883SC.AcceptChanges();
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC,
                    TipoAccion_883SC.ModificacionIdioma);

                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("IDI_MSG_GUARDADO"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
            }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
