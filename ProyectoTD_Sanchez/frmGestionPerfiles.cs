using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmGestionPerfiles_883SC : Form, IObservadorIdioma_883SC
    {
        PerfilBLL_883SC permisoBLL_883SC;
        BitacoraBLL_883SC bitacoraBLL_883SC = new BitacoraBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        //string PathFile = "GestionPerfiles";

        public frmGestionPerfiles_883SC()
        {
            InitializeComponent();
            permisoBLL_883SC = new PerfilBLL_883SC();
        }

        public void CargarComboFamilias_883SC()
        {
            comboFamilias.Items.Clear();

            foreach (var p in permisoBLL_883SC.ListaPermisos_883SC("Compuesto"))
            {
                comboFamilias.Items.Add(p.getPermisoNombre_883SC());
            }
        }

        private void MostrarPermisos_883SC()
        {
            checkedListBox1.Items.Clear();
            foreach (Permiso_883SC P in permisoBLL_883SC.ListaPermisos_883SC(""))
            {
                checkedListBox1.Items.Add(P.getPermisoNombre_883SC());
            }
        }

        private void CargarArbol_883SC()
        {
            treeView1.Nodes.Clear();
            List<Permiso_883SC> PermisoRaiz = permisoBLL_883SC.ListaPermisosRaiz_883SC();
            foreach (Permiso_883SC Pe in PermisoRaiz)
            {
                TreeNode tn = new TreeNode(Pe.getPermisoNombre_883SC());
                if (Pe is Familia_883SC familiaRaiz)
                {
                    if (familiaRaiz.EsRol_883SC)
                    {
                        tn.ForeColor = Color.Red; // Rojo para EsRol = true
                    }
                    else
                    {
                        tn.ForeColor = Color.Blue; // Azul para EsRol = false
                    }

                    LoadTreeRecursive_883SC(familiaRaiz, tn);
                }
                treeView1.Nodes.Add(tn);
            }
        }

        private void LoadTreeRecursive_883SC(Familia_883SC familiaActual, TreeNode parentNode)
        {
            foreach (var P in familiaActual.RetornarListaHijos_883SC())
            {
                TreeNode permisoHijo = new TreeNode(P.getPermisoNombre_883SC());
                if (P is Familia_883SC familiaHijo)
                {
                    if (familiaHijo.EsRol_883SC)
                    {
                        permisoHijo.ForeColor = Color.Red; // Rojo para EsRol = true
                    }
                    else
                    {
                        permisoHijo.ForeColor = Color.Blue; // Azul para EsRol = false
                    }

                    LoadTreeRecursive_883SC(familiaHijo, permisoHijo);
                }
                parentNode.Nodes.Add(permisoHijo);
            }
        }

        private void frmGestionPerfiles_Load_883SC(object sender, EventArgs e)
        {
            CargarArbol_883SC();
            MostrarPermisos_883SC();
            CargarComboFamilias_883SC();
            btnEliminar.Enabled = false;
            button7.Enabled = false;
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmGestionPerfiles_FormClosed_883SC;
        }

        private void frmGestionPerfiles_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        private void button5_Click_883SC(object sender, EventArgs e) // Agregar familia
        {
            try
            {
                if (permisoBLL_883SC.ValidarNombre_883SC(textBox2.Text))
                    throw new Exception("Nombre repetido");

                List<string> items = new List<string>();
                foreach (var CI in checkedListBox1.CheckedItems)
                {
                    items.Add(CI.ToString());
                }

                var familiasseleccionadas = checkedListBox1.CheckedItems.Cast<string>().ToList();
                foreach (var fam in familiasseleccionadas)
                {
                    List<Permiso_883SC> listaux = permisoBLL_883SC.ObtenerHijosDeFamilia_883SC(fam.ToString());
                    List<string> familiapermisos = listaux.Select(p => p.Nombre_883SC).ToList();

                    foreach (string pnombre in items)
                    {
                        if (familiapermisos.Contains(pnombre))
                        {
                            throw new Exception($"Permiso '{pnombre}' ya está asignado a '{fam}'");
                        }
                    }
                }
                if ((items.Count + familiasseleccionadas.Count) <= 1)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PERF_MSG_SELECCION"));
                    return;
                }

                Familia_883SC auxFamlia;
                if (rBFamilia.Checked)
                {
                    auxFamlia = new Familia_883SC(textBox2.Text, false);
                }
                else
                {
                    auxFamlia = new Familia_883SC(textBox2.Text, true);
                }

                permisoBLL_883SC.AgregarFamilia_883SC(auxFamlia);
                permisoBLL_883SC.AgregarPermisoFamilia_883SC(textBox2.Text, items);
                bitacoraBLL_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.AltaUsuario);

                CargarArbol_883SC();
                MostrarPermisos_883SC();
                CargarComboFamilias_883SC();
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect_883SC(object sender, TreeViewEventArgs e)
        {
        }

        private bool VerificarReferenciaCircular_883SC(Familia_883SC familiaBase, List<string> familiasagregadas)
        {
            foreach (var nombreFam in familiasagregadas)
            {
                var familiaAgregar = permisoBLL_883SC.ListaPermisosEnArbol_883SC().FirstOrDefault(f => f.Nombre_883SC == nombreFam) as Familia_883SC;

                if (familiaAgregar != null && VerificarReferenciaCircularRecursivo_883SC(familiaBase, familiaAgregar))
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerificarReferenciaCircularRecursivo_883SC(Familia_883SC familiaBase, Familia_883SC familiaAgregar)
        {
            if (familiaBase.Nombre_883SC == familiaAgregar.Nombre_883SC)
            {
                return true;
            }
            foreach (var hijo in familiaAgregar.RetornarListaHijos_883SC())
            {
                if (hijo is Familia_883SC hijoFamilia)
                {
                    if (VerificarReferenciaCircularRecursivo_883SC(familiaBase, hijoFamilia))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button7_Click_883SC(object sender, EventArgs e) //Modificar familia
        {
            try
            {
                Familia_883SC auxF = new Familia_883SC(comboFamilias.SelectedItem.ToString(), false);
                List<string> items = new List<string>();
                foreach (var CI in checkedListBox1.CheckedItems)
                {
                    items.Add(CI.ToString());
                }

                if (VerificarReferenciaCircular_883SC(permisoBLL_883SC.ListaPermisosEnArbol_883SC().Find(x => x.Nombre_883SC == comboFamilias.SelectedItem.ToString()) as Familia_883SC, items))
                {
                    throw new Exception("Referencia circular detectada");
                }

                var familiasseleccionadas = checkedListBox1.CheckedItems.Cast<string>().ToList();
                foreach (var fam in familiasseleccionadas)
                {
                    List<Permiso_883SC> listaux = permisoBLL_883SC.ObtenerHijosDeFamilia_883SC(fam.ToString());
                    List<string> familiapermisos = listaux.Select(p => p.Nombre_883SC).ToList();

                    foreach (string pnombre in items)
                    {
                        if (familiapermisos.Contains(pnombre))
                        {
                            throw new Exception($"Permiso '{pnombre}' ya está asignado a '{fam}'");
                        }
                    }
                }
                if ((items.Count + familiasseleccionadas.Count) <= 1)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("PERF_MSG_SELECCION"));
                    return;
                }

                permisoBLL_883SC.ModificarFamilia_883SC(auxF, items);
                bitacoraBLL_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.ModificacionUsuario);

                CargarArbol_883SC();
                MostrarPermisos_883SC();
                comboFamilias.SelectedIndex = -1;
                comboFamilias.Text = "";
                textBox2.Text = "";
                button5.Enabled = true;
                button7.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LimpiarChecklis_883SC()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        public void ChequearChecklist_883SC(Familia_883SC familia)
        {
            ChequearChecklistRecursivo_883SC(familia, false);
        }

        private void ChequearChecklistRecursivo_883SC(Familia_883SC familia, bool segundo)
        {
            foreach (var P in familia.RetornarListaHijos_883SC())
            {
                if (segundo)
                {
                    if (P is Familia_883SC)
                    {
                        int index = checkedListBox1.Items.IndexOf(P.getPermisoNombre_883SC());
                        if (index != -1)
                        {
                            checkedListBox1.SetItemChecked(index, true);
                        }
                    }
                }
                else
                {
                    int index = checkedListBox1.Items.IndexOf(P.getPermisoNombre_883SC());
                    if (index != -1)
                    {
                        checkedListBox1.SetItemChecked(index, true);
                    }
                }

                if (P is Familia_883SC)
                {
                    ChequearChecklistRecursivo_883SC((Familia_883SC)P, true);
                }
            }
        }

        private void comboFamilias_SelectedIndexChanged_883SC(object sender, EventArgs e)
        {
            try
            {
                LimpiarChecklis_883SC();

                if (comboFamilias.SelectedItem != null)
                {
                    List<Permiso_883SC> ListaPermisos = permisoBLL_883SC.ListaPermisosEnArbol_883SC();
                    Permiso_883SC seleccionado = ListaPermisos.Find(x => x.getPermisoNombre_883SC() == comboFamilias.SelectedItem.ToString());

                    ChequearChecklist_883SC((Familia_883SC)seleccionado);
                    btnEliminar.Enabled = true;
                    button5.Enabled = false;
                    button7.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool FamiliaContenida_883SC(string familiaAEliminar, Familia_883SC familiaActual)
        {
            // Recorrer la lista de hijos de la familia actual
            foreach (Permiso_883SC hijo in familiaActual.RetornarListaHijos_883SC())
            {
                // Si el hijo es la familia que se quiere eliminar, retornar true
                if (hijo is Familia_883SC && hijo.Nombre_883SC == familiaAEliminar)
                {
                    return true;
                }

                // Si el hijo es una familia, llamar recursivamente a la función
                if (hijo is Familia_883SC)
                {
                    if (FamiliaContenida_883SC(familiaAEliminar, (Familia_883SC)hijo))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnEliminar_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (comboFamilias.SelectedItem != null)
                {
                    List<Familia_883SC> ListaFamilias = permisoBLL_883SC.ListaPermisosEnArbol_883SC().OfType<Familia_883SC>().ToList();

                    foreach (Familia_883SC familia in ListaFamilias)
                    {
                        if (FamiliaContenida_883SC(comboFamilias.SelectedItem.ToString(), familia))
                        {
                            throw new Exception("La familia está en uso por otra familia");
                        }
                    }

                    if (permisoBLL_883SC.PerfilEnUso_883SC(comboFamilias.SelectedItem.ToString()))
                    {
                        throw new Exception($"El perfil está en uso: {comboFamilias.SelectedItem}");
                    }

                    permisoBLL_883SC.EliminarFamilia_883SC(new Familia_883SC(comboFamilias.SelectedItem.ToString(), false));
                    bitacoraBLL_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.BajaUsuario);

                    CargarArbol_883SC();
                    MostrarPermisos_883SC();
                    CargarComboFamilias_883SC();
                    comboFamilias.SelectedIndex = -1;
                    comboFamilias.Text = "";
                    button5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                CargarArbol_883SC();
                MostrarPermisos_883SC();
                comboFamilias.SelectedIndex = -1;
                comboFamilias.Text = "";
                textBox2.Text = "";
                button5.Enabled = true;
                btnEliminar.Enabled = false;
                button7.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("PERF_TITULO");
            labelTitulo.Text = gestorIdioma_883SC.Traducir_883SC("PERF_LBL_TITULO");
            gbDatos.Text = gestorIdioma_883SC.Traducir_883SC("PERF_GB_DATOS");
            gbPermisos.Text = gestorIdioma_883SC.Traducir_883SC("PERF_GB_PERMISOS");
            gbArbol.Text = gestorIdioma_883SC.Traducir_883SC("PERF_GB_ARBOL");
            labelNombre.Text = gestorIdioma_883SC.Traducir_883SC("PERF_LBL_NOMBRE");
            labelRol.Text = gestorIdioma_883SC.Traducir_883SC("PERF_LBL_ROL_FAMILIA");
            rBRol.Text = gestorIdioma_883SC.Traducir_883SC("PERF_RB_ROL");
            rBFamilia.Text = gestorIdioma_883SC.Traducir_883SC("PERF_RB_FAMILIA");
            button5.Text = gestorIdioma_883SC.Traducir_883SC("PERF_BTN_CREAR");
            button7.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_GUARDAR");
            btnEliminar.Text = gestorIdioma_883SC.Traducir_883SC("PERF_BTN_ELIMINAR");
            button1.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
        }

        #endregion
    }
}
