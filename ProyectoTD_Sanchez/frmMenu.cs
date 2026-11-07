using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System.Drawing;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmMenu_883SC : Form, IObservadorIdioma_883SC
    {
        public frmMenu_883SC()
        {
            InitializeComponent();
        }

        public static ToolStripMenuItem opcActivo_883SC = null;
        public static Form formActivo_883SC = null;
        UsuarioBLL_883SC usuario_883SC = new UsuarioBLL_883SC();
        BitacoraBLL_883SC bitacora_883SC = new BitacoraBLL_883SC();
        VerificadorIntegridadBLL_883SC verIntegridad_883SC = new VerificadorIntegridadBLL_883SC();
        PerfilBLL_883SC perfilBLL_883SC = new PerfilBLL_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private void frmMenu_Load_883SC(object sender, System.EventArgs e)
        {
            if (SessionManager_883SC.Logged_883SC())
            {
                FormConectado_883SC();
            }
            else
            {
                FormDesconectado_883SC();
            }
            CargarMenuIdiomas_883SC();
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmMenu_FormClosed_883SC;
        }

        private void frmMenu_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            tsInicio.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_INICIO");
            iniciarSesionToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_INICIAR_SESION");
            cerrarSesionToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_CERRAR_SESION");
            salirToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
            tsAdmin.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_ADMIN");
            gestionDeUsuariosToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_GESTION_USUARIOS");
            tsPerfiles.Text = gestorIdioma_883SC.Traducir_883SC("MENU_PERFILES");
            idiomasToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_IDIOMAS");
            backupToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_BACKUP");
            restoreToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_RESTORE");
            bitacoraToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_BITACORA");
            tsUsuario.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_USUARIO");
            cambiarClaveToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_CAMBIAR_CLAVE");
            cambiarIdiomaToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_CAMBIAR_IDIOMA");
            tsVentas.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_VENTAS");
            llenarCarritoToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_LLENAR_CARRITO");
            realizarVentaToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_REALIZAR_VENTA");
            tsMaestros.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_MAESTROS");
            usuariosToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_MAESTRO_USUARIOS");
            clientesToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_MAESTRO_CLIENTES");
            proveedoresToolStripMenuItem1.Text = gestorIdioma_883SC.Traducir_883SC("MENU_MAESTRO_PROVEEDORES");
            productosToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_MAESTRO_PRODUCTOS");
            tsGestion.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_GESTION");
            altaProveedorToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_PROVEEDORES");
            administrarProductosToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_PRODUCTOS");
            tsCompras.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_COMPRAS");
            importarListaToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_IMPORTAR_LISTA");
            generarOrdenesToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_GENERAR_ORDENES");
            autorizarOrdenesToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_AUTORIZAR_ORDENES");
            registrarRecepcionToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_REGISTRAR_RECEPCION");
            tsReportes.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_REPORTES");
            tsAyuda.Text = gestorIdioma_883SC.Traducir_883SC("MENU_TS_AYUDA");
            hToolStripMenuItem.Text = gestorIdioma_883SC.Traducir_883SC("MENU_HISTORIAL");

            if (SessionManager_883SC.Logged_883SC() && SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC() != null)
            {
                lblUsuario.Text = gestorIdioma_883SC.Traducir_883SC("MENU_LBL_USUARIO") + SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC;
            }
            else
            {
                lblUsuario.Text = gestorIdioma_883SC.Traducir_883SC("MENU_LBL_SIN_CONEXION");
            }
            MarcarIdiomaActivo_883SC();
        }

        private void CargarMenuIdiomas_883SC()
        {
            try
            {
                cambiarIdiomaToolStripMenuItem.DropDownItems.Clear();
                foreach (IdiomaBE_883SC idioma in gestorIdioma_883SC.ObtenerIdiomas_883SC())
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(idioma.Nombre_883SC);
                    item.Tag = idioma.Codigo_883SC;
                    item.Click += itemIdioma_Click_883SC;
                    cambiarIdiomaToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch { }//Sin conexion a la BD no se ofrece el cambio de idioma
        }

        private void MarcarIdiomaActivo_883SC()
        {
            foreach (ToolStripMenuItem item in cambiarIdiomaToolStripMenuItem.DropDownItems)
            {
                item.Checked = gestorIdioma_883SC.IdiomaActual_883SC != null
                    && item.Tag.ToString() == gestorIdioma_883SC.IdiomaActual_883SC.Codigo_883SC;
            }
        }

        private void itemIdioma_Click_883SC(object sender, System.EventArgs e)
        {
            try
            {
                gestorIdioma_883SC.CambiarIdioma_883SC((sender as ToolStripMenuItem).Tag.ToString());
                string user = SessionManager_883SC.Logged_883SC() ? SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC : "null";
                bitacora_883SC.RegistrarBitacora_883SC(user, TipoAccion_883SC.CambioIdioma);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_ERROR_BD") + ex.Message);
            }
        }

        #endregion


        #region Set Formulario
        public void FormConectado_883SC()
        {
            UsuarioBE_883SC usActual = SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC();
            lblUsuario.Text = "Usuario: " + usActual.user_883SC;
            iniciarSesionToolStripMenuItem.Enabled = false;
            cerrarSesionToolStripMenuItem.Enabled = true;
            tsAdmin.Enabled = true;
            tsReportes.Enabled = true;
            tsMaestros.Enabled = true;
            tsGestion.Enabled = true;
            tsCompras.Enabled = true;
            cambiarClaveToolStripMenuItem.Enabled = true;

            AplicarPermisos_883SC(usActual.rol_883SC);
        }

        private void AplicarPermisos_883SC(string rol)
        {
            gestionDeUsuariosToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionUsuarios.ToString());
            tsPerfiles.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionPerfiles.ToString());
            backupToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionBackup.ToString());
            restoreToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionBackup.ToString());
            bitacoraToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionBitacora.ToString());
            llenarCarritoToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.LlenarCarrito.ToString());
            realizarVentaToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.RealizarCobro.ToString());
            usuariosToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionUsuarios.ToString());
            clientesToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.RegistrarCliente.ToString());
            productosToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionProductos.ToString());
            proveedoresToolStripMenuItem1.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionProductos.ToString());
            altaProveedorToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.RegistrarProveedor.ToString());
            administrarProductosToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GestionProductos.ToString());
            importarListaToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.ImportarListaPrecios.ToString());
            generarOrdenesToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.GenerarOrdenCompra.ToString());
            autorizarOrdenesToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.AutorizarOrdenCompra.ToString());
            registrarRecepcionToolStripMenuItem.Enabled = perfilBLL_883SC.TienePermiso_883SC(rol, TipoPermiso_883SC.RegistrarRecepcion.ToString());
        }

        public void FormDesconectado_883SC()
        {
            lblUsuario.Text = "Usuario: Sin Conexion";
            iniciarSesionToolStripMenuItem.Enabled = true;
            cerrarSesionToolStripMenuItem.Visible = false;
            tsAdmin.Visible = false;
            tsReportes.Visible = false;
            tsMaestros.Visible = false;
            tsGestion.Visible = false;
            tsCompras.Visible = false;
            cambiarClaveToolStripMenuItem.Visible = false;
        }

        #endregion

        private void OpenForm_883SC(ToolStripMenuItem opc, Form frm)
        {
            if (opcActivo_883SC != null)
            {
                opcActivo_883SC.BackColor = Color.WhiteSmoke;
            }
            opc.BackColor = Color.Gainsboro;
            opcActivo_883SC = opc;

            if (formActivo_883SC != null) { formActivo_883SC.Close(); }
            formActivo_883SC = frm;
            frm.MdiParent = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            frm.Show();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.GestionUsuariosAbierta);
            OpenForm_883SC(tsAdmin, new frmUsuario_883SC());
        }

        private void usuariosMaestro_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsMaestros, new frmMaestro_883SC(TipoMaestro_883SC.Usuarios));
        }

        private void clientesMaestro_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsMaestros, new frmClientes_883SC());
        }

        private void proveedoresMaestro_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsMaestros, new frmMaestro_883SC(TipoMaestro_883SC.Proveedores));
        }

        private void productosMaestro_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsMaestros, new frmMaestro_883SC(TipoMaestro_883SC.Productos));
        }

        private void altaProveedorToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmAltaProveedor_883SC frmAlta = new frmAltaProveedor_883SC();
            frmAlta.ShowDialog();
        }

        private void administrarProductosToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsGestion, new frmAdministrarProductos_883SC());
        }

        private void importarListaToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsCompras, new frmImportarListaPrecios_883SC());
        }

        private void generarOrdenesToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsCompras, new frmGenerarOrdenesCompra_883SC());
        }

        private void autorizarOrdenesToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsCompras, new frmAutorizarOrdenesCompra_883SC());
        }

        private void registrarRecepcionToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsCompras, new frmRegistrarRecepcion_883SC());
        }

        private void salirToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_CONFIRMA_SALIR_APP"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.AppClose);
                if (SessionManager_883SC.Logged_883SC())
                {
                    verIntegridad_883SC.ActualizarDVVSiVerificado_883SC();
                }
                SessionManager_883SC.GetInstance_883SC.Logout_883SC();
                Application.Exit();
            }
        }

        private void cerrarSesionToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(gestorIdioma_883SC.Traducir_883SC("COMUN_CONFIRMA_CERRAR_SESION"), gestorIdioma_883SC.Traducir_883SC("COMUN_ATENCION"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UsuarioBLL_883SC usuario = new UsuarioBLL_883SC();
                usuario.Logout_883SC();

                frmLogin_883SC frm = new frmLogin_883SC();
                frm.Show();
                this.Close();
            }
        }

        private void iniciarSesionToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmLogin_883SC frm = new frmLogin_883SC();
            frm.Show();
            this.Close();
        }

        private void cambiarClaveToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmModClave_883SC frmClave = new frmModClave_883SC();
            frmClave.ShowDialog();
        }

        private void bitacoraToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            bitacora_883SC.RegistrarBitacora_883SC(SessionManager_883SC.GetInstance_883SC.UsuarioActual_883SC().user_883SC, TipoAccion_883SC.BitacoraAbierta);
            OpenForm_883SC(tsAdmin, new frmBitacora_883SC());
        }

        private void perfilesToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmGestionPerfiles_883SC frmperfil = new frmGestionPerfiles_883SC();
            frmperfil.ShowDialog();
            //OpenForm(tsPerfiles, new frmGestionPerfiles());
        }

        private void llenarCarritoToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsVentas, new frmLlenarCarrito_883SC());
        }

        private void realizarVentaToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsVentas, new frmRealizarVenta_883SC());
        }

        private void hToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmHistorialUsuario_883SC frmhistorial = new frmHistorialUsuario_883SC();
            frmhistorial.ShowDialog();
        }

        private void backupToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            OpenForm_883SC(tsAdmin, new frmBackup_883SC());
        }

        private void restoreToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmRestore_883SC frmRestore = new frmRestore_883SC();
            if (frmRestore.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void idiomasToolStripMenuItem_Click_883SC(object sender, System.EventArgs e)
        {
            frmIdiomas_883SC frmIdiomas = new frmIdiomas_883SC();
            frmIdiomas.ShowDialog();
            CargarMenuIdiomas_883SC();
            MarcarIdiomaActivo_883SC();
        }
    }
}
