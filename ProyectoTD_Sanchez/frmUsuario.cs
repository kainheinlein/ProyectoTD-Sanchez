using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmUsuario_883SC : Form,IObservadorIdioma_883SC
    {
        public frmUsuario_883SC()
        {
            InitializeComponent();
        }

        UsuarioBE_883SC auxUsuario_883SC;
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        UsuarioBLL_883SC usuarioBLL_883SC = new UsuarioBLL_883SC();
        PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;
        int varMod_883SC = 0; //Indica si la modificacion esta activa
        List<string> roles_883SC = new List<string>();
        //{ "Cajero", "Vendedor", "Administrador" };

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("USU_TITULO");
            label1.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_TITULO");
            label2.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_OPCIONES");
            gbDatos.Text = gestorIdioma_883SC.Traducir_883SC("USU_GB_DATOS");
            g.Text = gestorIdioma_883SC.Traducir_883SC("USU_GB_MENSAJES");
            label3.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_DNI");
            label4.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_NOMBRE");
            label5.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_APELLIDO");
            label6.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            label7.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_ROL");
            label8.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_DIRECCION");
            label9.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_TELEFONO");
            label10.Text = gestorIdioma_883SC.Traducir_883SC("USU_LBL_EMAIL");
            chkActivo.Text = gestorIdioma_883SC.Traducir_883SC("USU_CHK_ACTIVO");
            chkBloqueado.Text = gestorIdioma_883SC.Traducir_883SC("USU_CHK_BLOQUEADO");
            btnCrearUs.Text = gestorIdioma_883SC.Traducir_883SC("USU_BTN_CREAR");
            btnModUs.Text = gestorIdioma_883SC.Traducir_883SC("USU_BTN_MODIFICAR");
            btnElimUs.Text = gestorIdioma_883SC.Traducir_883SC("USU_BTN_ELIMINAR");
            btnDesbloquear.Text = gestorIdioma_883SC.Traducir_883SC("USU_BTN_DESBLOQUEAR");
            btnGuardar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_GUARDAR");
            btnCancelar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_CANCELAR");
            btnSalir.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            TraducirColumnas_883SC();
        }

        private void TraducirColumnas_883SC()
        {
            if (dgvUsuarios.Columns.Count == 0) { return; }
            dgvUsuarios.Columns[1].HeaderText = gestorIdioma_883SC.Traducir_883SC("USU_LBL_DNI");
            dgvUsuarios.Columns[2].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_NOMBRE");
            dgvUsuarios.Columns[3].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_APELLIDO");
            dgvUsuarios.Columns[4].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            dgvUsuarios.Columns[5].HeaderText = gestorIdioma_883SC.Traducir_883SC("COMUN_ROL");
            dgvUsuarios.Columns[10].HeaderText = gestorIdioma_883SC.Traducir_883SC("USU_CHK_ACTIVO");
            dgvUsuarios.Columns[11].HeaderText = gestorIdioma_883SC.Traducir_883SC("USU_CHK_BLOQUEADO");
        }

        #endregion

        #region Funciones

        private void ConfigDefaultForm_883SC()
        {
            HabilitarBtn_883SC(btnGuardar, false);
            HabilitarBtn_883SC(btnCancelar, false);
            cmbRol.Enabled = false;
            HabilitarBtn_883SC(btnCrearUs, true);
            HabilitarBtn_883SC(btnModUs, false);
            HabilitarBtn_883SC(btnElimUs, false);
            HabilitarBtn_883SC(btnDesbloquear, false);
            dgvUsuarios.Enabled = true;
            chkActivo.Enabled = false;
            varMod_883SC = 0;
            foreach (Control c in pUsuario.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.Enabled) { btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold); btn.ForeColor = Color.Black; }
                    else { btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Regular); }
                    c.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
            LimpiarDatos_883SC();

            foreach (Control control in gbDatos.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = false;
                }
            }
        }

        private void HabilitarBtn_883SC(Button btn, bool tipo)
        {
            if (tipo)
            {
                btn.Enabled = tipo;
                btn.Font = new Font(btn.Font.Name, btnGuardar.Font.Size, FontStyle.Bold);
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.Font = new Font(btn.Font.Name, btnGuardar.Font.Size, FontStyle.Regular);
                btn.Enabled = tipo;
            }
        }

        private Button ultimoBoton_883SC = null;

        private void ClickBoton_883SC(object sender, EventArgs e)
        {
            if (ultimoBoton_883SC != null)
            {
                ultimoBoton_883SC.BackColor = Color.FromArgb(255, 192, 192);
            }

            if ((sender as Button).Text != "Cancelar")
            {
                (sender as Button).BackColor = Color.LightCoral;
            }
            ultimoBoton_883SC = (sender as Button);
        }

        private void HabilitarCampos_883SC()
        {
            foreach (Control control in gbDatos.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = true;
                    textBox.BackColor = Color.White;
                }
                cmbRol.Enabled = true;
            }
        }

        private void LimpiarDatos_883SC()
        {
            foreach (Control control in gbDatos.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                    textBox.BackColor = Color.Gainsboro;
                }
            }
            cmbRol.SelectedItem = null;
            chkBloqueado.Checked = false;
            chkActivo.Checked = false;
            txtDoc.Focus();
        }

        private void ConfigDGV_883SC(List<UsuarioBE_883SC> usuarios)
        {
            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Columns["dir_883SC"].Visible = false;
            dgvUsuarios.Columns["tel_883SC"].Visible = false;
            dgvUsuarios.Columns["email_883SC"].Visible = false;
            dgvUsuarios.Columns["cod_883SC"].Visible = false;
            dgvUsuarios.Columns["pass_883SC"].Visible = false;
            dgvUsuarios.Columns["dvh_883SC"].Visible = false;
            dgvUsuarios.Columns["digito_883SC"].Visible = false;
            dgvUsuarios.Columns["ape_883SC"].HeaderText = "Apellido";
            dgvUsuarios.Columns["nomb_883SC"].HeaderText = "Nombre";
            dgvUsuarios.Columns["dni_883SC"].HeaderText = "DNI";
            dgvUsuarios.Columns["user_883SC"].HeaderText = "Usuario";
            dgvUsuarios.Columns["rol_883SC"].HeaderText = "Rol";
            dgvUsuarios.Columns["estado_883SC"].HeaderText = "Activo";
            dgvUsuarios.Columns["bloq_883SC"].HeaderText = "Bloqueado";
            dgvUsuarios.ReadOnly = true;
        }

        private void ActualizarDGV_883SC()
        {
            dgvUsuarios.DataSource = usuarioBLL_883SC.ListarUsuarios_883SC();
            ConfigDefaultForm_883SC();
        }

        private UsuarioBE_883SC CargaUsuario_883SC()
        {
            if (ValCampos_883SC())//Validacion caracteres
            {
                if(varMod_883SC == 1) { auxUsuario_883SC = ExtraerDatos_883SC(dgvUsuarios.SelectedRows[0]); }
                else auxUsuario_883SC = new UsuarioBE_883SC();

                auxUsuario_883SC.dni_883SC = Convert.ToInt32(txtDoc.Text);
                auxUsuario_883SC.nomb_883SC = txtNom.Text;
                auxUsuario_883SC.ape_883SC = txtApe.Text;
                auxUsuario_883SC.rol_883SC = cmbRol.SelectedValue.ToString();
                auxUsuario_883SC.user_883SC = txtUsu.Text;
                auxUsuario_883SC.estado_883SC = chkActivo.Checked;
                auxUsuario_883SC.bloq_883SC = chkBloqueado.Checked;
                if (txtDir.Text == string.Empty) { auxUsuario_883SC.dir_883SC = " "; }
                else { auxUsuario_883SC.dir_883SC = txtDir.Text; }
                if (txtTel.Text == string.Empty) { auxUsuario_883SC.tel_883SC = " "; }
                else { auxUsuario_883SC.tel_883SC = txtTel.Text; }
                if (txtMail.Text == string.Empty) { auxUsuario_883SC.email_883SC = " "; }
                else { auxUsuario_883SC.email_883SC = txtMail.Text; }

                return auxUsuario_883SC;
            }
            return null;
        }

        private void GuardarEnabled_883SC()
        {
            if (txtNom.Text != "" & txtApe.Text != "" & txtDoc.Text != ""
                    & txtUsu.Text != "" & cmbRol.SelectedValue != null)
            {
                HabilitarBtn_883SC(btnGuardar, true);
            }
            else
            {
                HabilitarBtn_883SC(btnGuardar, false);
            }
        }

        private void CampoError_883SC(string campo)
        //Marcar en rojo los campos con validacion no ok
        {
            foreach (Control t in gbDatos.Controls)
            {
                if (t is TextBox & (t.Name == campo))
                {
                    t.BackColor = Color.LightCoral;
                    break;
                }
            }
        }

        private UsuarioBE_883SC ExtraerDatos_883SC(DataGridViewRow fila)
        {
            string[] datos = new string[fila.Cells.Count];

            for (int i = 0; i < fila.Cells.Count; i++)
            {
                datos[i] = fila.Cells[i].Value.ToString();
            }
            auxUsuario_883SC = new UsuarioBE_883SC();
            return auxUsuario_883SC.CrearUsuario_883SC(datos);
        }

        private void LlenarMensaje_883SC(string linea)
        {
            txtMensaje.Text = linea + Environment.NewLine + Environment.NewLine + txtMensaje.Text;
        }

        #endregion

        #region ValidacionCampos
        private void txtDoc_TextChanged_883SC(object sender, EventArgs e)
        {
            txtDoc.BackColor = Color.White;
            txtDoc.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtNom_TextChanged_883SC(object sender, EventArgs e)
        {
            txtNom.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtApe_TextChanged_883SC(object sender, EventArgs e)
        {
            txtApe.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtUsu_TextChanged_883SC(object sender, EventArgs e)
        {
            txtUsu.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtDir_TextChanged_883SC(object sender, EventArgs e)
        {
            txtDir.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtTel_TextChanged_883SC(object sender, EventArgs e)
        {
            txtTel.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void txtMail_TextChanged_883SC(object sender, EventArgs e)
        {
            txtMail.BackColor = Color.White;
            GuardarEnabled_883SC();
        }

        private void cmbRol_SelectedValueChanged_883SC(object sender, EventArgs e)
        {
            GuardarEnabled_883SC();
        }

        private bool ValCampos_883SC()
        {
            string patronT = @"^[a-zA-Z\s]+$";
            string patronD = @"^[A-Za-z0-9\s]+$";
            string patronN = "^[0-9]+$";
            string patronS = "^[A-Za-z0-9]+$";
            string patronM = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            bool txtOK, numOK, sensOK, dirOK, mailOK;
            txtOK = numOK = sensOK = dirOK = mailOK = true;

            foreach (Control t in gbDatos.Controls)
            {
                if (t is TextBox)
                {
                    //Validacion Nombre y Apellido
                    if (t.Name == "txtNom" || t.Name == "txtApe")
                    {
                        if (!Regex.IsMatch(t.Text, patronT))
                        {
                            CampoError_883SC(t.Name);
                            txtOK = false;
                        }
                    }
                    else
                    {
                        //Validacion Direccion
                        if (t.Name == "txtDir")
                        {
                            if (!Regex.IsMatch(t.Text, patronD) & t.Text != string.Empty)
                            {
                                CampoError_883SC(t.Name);
                                dirOK = false;
                            }
                        }
                        else
                        {
                            //Validacion User y Pass
                            if (t.Name == "txtUsu")
                            {
                                if (!Regex.IsMatch(t.Text, patronS))
                                {
                                    CampoError_883SC(t.Name);
                                    sensOK = false;
                                }
                            }
                            else
                            {
                                //Validacion DNI y Telefono
                                if ((t.Name == "txtTel" & t.Text != string.Empty) || t.Name == "txtDoc")
                                {
                                    if (!Regex.IsMatch(t.Text, patronN))
                                    {
                                        CampoError_883SC(t.Name);
                                        numOK = false;
                                    }
                                }
                                else
                                {
                                    //Validacion Mail
                                    if (t.Name == "txtMail" & t.Text != string.Empty)
                                    {
                                        if (!Regex.IsMatch(t.Text, patronM))
                                        {
                                            CampoError_883SC(t.Name);
                                            mailOK = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #region Texto de error en Campo Mensajes
            if (!txtOK)
            {
                LlenarMensaje_883SC("Campos Nombre y/o Apellido contienen caracteres no validos." +
                    "Ingrese solo letras por favor.");
            }

            if (!numOK)
            {
                LlenarMensaje_883SC("Campos DNI y/o Telefono contienen caracteres no validos." +
                    "Ingrese solo numeros por favor.");
            }

            if (!dirOK)
            {
                LlenarMensaje_883SC("Campo Direccion contiene caracteres no validos." +
                    "Ingrese solo letras y numeros por favor.");
            }

            if (!sensOK)
            {
                LlenarMensaje_883SC("Campo Usuario contiene caracteres no validos." +
                    "No se permiten espacios ni caracteres especiales.");
            }

            if (!mailOK)
            {
                LlenarMensaje_883SC("Campo eMail contiene caracteres no validos." +
                    "Respete el formato xxxx@xxx.xxx, sin espacios ni caracteres especiales.");
            }
            #endregion

            if (!txtOK || !sensOK || !dirOK || !numOK || !mailOK)
            {
                txtDoc.Focus();
                return false;
            }
            else { return true; }
        }
        #endregion

        private void frmUsuario_Load_883SC(object sender, EventArgs e)
        {
            try
            {
                ConfigDGV_883SC(usuarioBLL_883SC.ListarUsuarios_883SC());
                try
                {
                    List<Permiso_883SC> permisosRol = perfilBLL_883SC.ListaPermisos_883SC("Rol");
                    roles_883SC.Clear();
                    foreach (var permiso in permisosRol)
                    {
                        roles_883SC.Add(permiso.Nombre_883SC);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("USU_ERR_ROLES") + ex.Message);
                    roles_883SC = new List<string>() { "Cajero", "Vendedor", "Admin" };
                }
                cmbRol.DataSource = new BindingSource(roles_883SC, null);
                ConfigDefaultForm_883SC();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmUsuario_FormClosed_883SC;
        }

        private void frmUsuario_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        private void dgvUsuarios_CellClick_883SC(object sender, DataGridViewCellEventArgs e)
        {
            //Carga de datos de fila seleccionada a textbox
            if (e.RowIndex >= 0)
            {

                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtDoc.Text = fila.Cells["dni_883SC"].Value.ToString();
                txtNom.Text = fila.Cells["nomb_883SC"].Value.ToString();
                txtApe.Text = fila.Cells["ape_883SC"].Value.ToString();
                cmbRol.SelectedIndex = cmbRol.Items.IndexOf(Convert.ToString(fila.Cells["rol_883SC"].Value));
                txtUsu.Text = fila.Cells["user_883SC"].Value.ToString();
                txtDir.Text = fila.Cells["dir_883SC"].Value.ToString();
                txtTel.Text = fila.Cells["tel_883SC"].Value.ToString();
                txtMail.Text = fila.Cells["email_883SC"].Value.ToString();
                if (Convert.ToBoolean(fila.Cells["estado_883SC"].Value) == true)
                {
                    chkActivo.Checked = true;
                    HabilitarBtn_883SC(btnElimUs, true);
                }
                else
                {
                    chkActivo.Checked = false;
                    HabilitarBtn_883SC(btnElimUs, false);
                }
                if (Convert.ToBoolean(fila.Cells["bloq_883SC"].Value) == true)
                {
                    chkBloqueado.Checked = true;
                    HabilitarBtn_883SC(btnDesbloquear, true);
                }
                else
                {
                    chkBloqueado.Checked = false;
                    HabilitarBtn_883SC(btnDesbloquear, false);
                }
                HabilitarBtn_883SC(btnCancelar, true);
                HabilitarBtn_883SC(btnModUs, true);
                HabilitarBtn_883SC(btnGuardar, false);
            }
            else { ConfigDefaultForm_883SC(); }
        }

        private void btnSalir_Click_883SC(object sender, EventArgs e)
        {
            auxUsuario_883SC = null;
            Control control = btnSalir.Parent;
            frmMenu_883SC.opcActivo_883SC.BackColor = Color.WhiteSmoke;
            this.Close();
        }

        private void btnCrearUs_Click_883SC(object sender, EventArgs e)
        {
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarBtn_883SC(btnDesbloquear, false);
            HabilitarBtn_883SC(btnCrearUs, false);
            HabilitarBtn_883SC(btnElimUs, false);
            HabilitarBtn_883SC(btnModUs, false);
            dgvUsuarios.Enabled = false;
            LimpiarDatos_883SC();
            HabilitarCampos_883SC();
            chkActivo.Checked = true;
            ClickBoton_883SC(sender, e);
        }

        private void btnCancelar_Click_883SC(object sender, EventArgs e)
        {
            ConfigDefaultForm_883SC();
            ClickBoton_883SC(sender, e);
        }

        private void btnGuardar_Click_883SC(object sender, EventArgs e)
        {
            UsuarioBE_883SC us = CargaUsuario_883SC();

            if (us != null)
            {
                int error = 0;

                if (varMod_883SC == 0) //Guardar Usuario Nuevo
                {
                    foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells[3].Value) == us.dni_883SC)
                        {
                            LlenarMensaje_883SC(gestorIdioma_883SC.Traducir_883SC("USU_MSG_DNI_EXISTE"));
                            ConfigDefaultForm_883SC();
                            error = 1;
                            break;
                        }
                        else
                        {
                            if (fila.Cells[4].Value.ToString() == us.user_883SC)
                            {
                                LlenarMensaje_883SC(gestorIdioma_883SC.Traducir_883SC("USU_MSG_USER_EXISTE"));
                                txtUsu.Text = "";
                                error = 1;
                                break;
                            }
                        }
                    }
                    if (error == 0)
                    {
                        try
                        {
                            us.pass_883SC = usuarioBLL_883SC.GenerarPass_883SC(us.ape_883SC, us.dni_883SC.ToString());
                            usuarioBLL_883SC.CrearUsuario_883SC(us);
                            ActualizarDGV_883SC();
                            LlenarMensaje_883SC(string.Format(gestorIdioma_883SC.Traducir_883SC("USU_MSG_CREADO"), us.user_883SC));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("USU_ERR_CREAR") + ex.Message);
                            ConfigDefaultForm_883SC();
                        }
                    }
                }
                else //Guardar Usuario Modificado
                {
                    try
                    {
                        us.cod_883SC = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
                        usuarioBLL_883SC.ActualizarUsuario_883SC(us);
                        ActualizarDGV_883SC();
                        LlenarMensaje_883SC(string.Format(gestorIdioma_883SC.Traducir_883SC("USU_MSG_ACTUALIZADO"), us.user_883SC));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("USU_ERR_ACTUALIZAR") + ex.Message);
                        ConfigDefaultForm_883SC();
                    }
                }
            }
        }

        private void btnModUs_Click_883SC(object sender, EventArgs e)
        {
            varMod_883SC = 1;
            HabilitarBtn_883SC(btnCancelar, true);
            HabilitarBtn_883SC(btnDesbloquear, false);
            HabilitarBtn_883SC(btnCrearUs, false);
            HabilitarBtn_883SC(btnElimUs, false);
            HabilitarBtn_883SC(btnModUs, false);
            dgvUsuarios.Enabled = false;
            chkActivo.Enabled = true;
            HabilitarBtn_883SC(btnGuardar, true);
            HabilitarCampos_883SC();
            if (txtTel.Text == " ") { txtTel.Clear(); }
            if (txtDir.Text == " ") { txtDir.Clear(); }
            if (txtMail.Text == " ") { txtMail.Clear(); }
        }

        private void btnElimUs_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                UsuarioBE_883SC us = ExtraerDatos_883SC(dgvUsuarios.SelectedRows[0]);
                if (MessageBox.Show(string.Format(gestorIdioma_883SC.Traducir_883SC("USU_MSG_CONFIRMA_ELIMINAR"), us.user_883SC), gestorIdioma_883SC.Traducir_883SC("USU_BTN_ELIMINAR"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    us.estado_883SC = false;
                    usuarioBLL_883SC.EliminarUs_883SC(us);
                    ActualizarDGV_883SC();
                    LlenarMensaje_883SC(string.Format(gestorIdioma_883SC.Traducir_883SC("USU_MSG_BAJA_OK"), us.user_883SC));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("USU_ERR_ELIMINAR") + ex.Message);
                ConfigDefaultForm_883SC();
            }
        }

        private void btnDesbloquear_Click_883SC(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("USU_MSG_CONFIRMA_DESBLOQUEO"), gestorIdioma_883SC.Traducir_883SC("USU_TIT_DESBLOQUEAR"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuarioBE_883SC aux = new UsuarioBE_883SC();
                    aux = ExtraerDatos_883SC(dgvUsuarios.SelectedRows[0]);
                    usuarioBLL_883SC.DesbloquearUS_883SC(aux);
                    LlenarMensaje_883SC(gestorIdioma_883SC.Traducir_883SC("USU_MSG_DESBLOQUEO_OK"));
                    ActualizarDGV_883SC();
                }
            }
            catch (Exception ex) { MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message); }
        }
    }
}
