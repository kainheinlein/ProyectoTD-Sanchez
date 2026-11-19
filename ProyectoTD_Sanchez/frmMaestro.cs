using Entidad_BE;
using Negocio_BLL;
using Servicios;
using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public enum TipoMaestro_883SC
    {
        Usuarios,
        Clientes,
        Productos,
        Proveedores
    }

    //Tabla maestra de solo lectura.
    public partial class frmMaestro_883SC : Form, IObservadorIdioma_883SC
    {
        public frmMaestro_883SC(TipoMaestro_883SC tipo)
        {
            InitializeComponent();
            tipo_883SC = tipo;
        }

        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        private TipoMaestro_883SC tipo_883SC;

        private void frmMaestro_Load_883SC(object sender, EventArgs e)
        {
            ConfigurarColumnas_883SC();
            CargarDatos_883SC();

            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += frmMaestro_FormClosed_883SC;
        }

        private void frmMaestro_FormClosed_883SC(object sender, FormClosedEventArgs e)
        {
            gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        #region Patron Observer - Idiomas

        public void ActualizarTextos_883SC()
        {
            lblTitulo.Text = Traducir_883SC(ClaveTitulo_883SC());
            btnCerrar.Text = Traducir_883SC("COMUN_SALIR");
            foreach (DataGridViewColumn columna in dgvMaestro.Columns)
            {
                columna.HeaderText = Traducir_883SC(columna.Tag.ToString());
            }
        }

        #endregion

        private string Traducir_883SC(string clave)
        {
            return gestorIdioma_883SC.Traducir_883SC(clave);
        }

        private string ClaveTitulo_883SC()
        {
            switch (tipo_883SC)
            {
                case TipoMaestro_883SC.Usuarios: return "MAESTRO_TIT_USUARIOS";
                case TipoMaestro_883SC.Clientes: return "MAESTRO_TIT_CLIENTES";
                case TipoMaestro_883SC.Productos: return "MAESTRO_TIT_PRODUCTOS";
                default: return "MAESTRO_TIT_PROVEEDORES";
            }
        }

        private void AgregarColumna_883SC(string propiedad, string claveEncabezado, bool booleana = false, string formato = null)
        {
            DataGridViewColumn columna = booleana ? (DataGridViewColumn)new DataGridViewCheckBoxColumn() : new DataGridViewTextBoxColumn();
            columna.DataPropertyName = propiedad;
            columna.Name = "col" + propiedad;
            columna.Tag = claveEncabezado;
            columna.ReadOnly = true;
            if (formato != null) { columna.DefaultCellStyle.Format = formato; }
            dgvMaestro.Columns.Add(columna);
        }

        private void ConfigurarColumnas_883SC()
        {
            dgvMaestro.AutoGenerateColumns = false;
            dgvMaestro.Columns.Clear();

            switch (tipo_883SC)
            {
                case TipoMaestro_883SC.Usuarios:
                    //No se muestran la contrasena ni el digito verificador.
                    AgregarColumna_883SC("dni_883SC", "MAESTRO_COL_DNI");
                    AgregarColumna_883SC("user_883SC", "COMUN_USUARIO");
                    AgregarColumna_883SC("nomb_883SC", "COMUN_NOMBRE");
                    AgregarColumna_883SC("ape_883SC", "COMUN_APELLIDO");
                    AgregarColumna_883SC("rol_883SC", "COMUN_ROL");
                    AgregarColumna_883SC("dir_883SC", "MAESTRO_COL_DIRECCION");
                    AgregarColumna_883SC("tel_883SC", "MAESTRO_COL_TELEFONO");
                    AgregarColumna_883SC("email_883SC", "MAESTRO_COL_EMAIL");
                    AgregarColumna_883SC("estado_883SC", "MAESTRO_COL_ACTIVO", true);
                    AgregarColumna_883SC("bloq_883SC", "MAESTRO_COL_BLOQUEADO", true);
                    break;
                case TipoMaestro_883SC.Clientes:
                    AgregarColumna_883SC("Dni_883SC", "MAESTRO_COL_DNI");
                    AgregarColumna_883SC("Nombre_883SC", "COMUN_NOMBRE");
                    AgregarColumna_883SC("Apellido_883SC", "COMUN_APELLIDO");
                    AgregarColumna_883SC("Direccion_883SC", "MAESTRO_COL_DIRECCION");
                    AgregarColumna_883SC("Telefono_883SC", "MAESTRO_COL_TELEFONO");
                    break;
                case TipoMaestro_883SC.Productos:
                    AgregarColumna_883SC("Codigo_883SC", "MAESTRO_COL_CODIGO");
                    AgregarColumna_883SC("Nombre_883SC", "COMUN_NOMBRE");
                    AgregarColumna_883SC("Tipo_883SC", "MAESTRO_COL_DESCRIPCION");
                    AgregarColumna_883SC("Stock_883SC", "MAESTRO_COL_STOCK");
                    AgregarColumna_883SC("Precio_883SC", "MAESTRO_COL_PRECIO", false, "N2");
                    AgregarColumna_883SC("Proveedor_883SC", "MAESTRO_COL_PROVEEDOR");
                    break;
                default:
                    AgregarColumna_883SC("Id_883SC", "MAESTRO_COL_ID");
                    AgregarColumna_883SC("Nombre_883SC", "COMUN_NOMBRE");
                    AgregarColumna_883SC("Especialidad_883SC", "MAESTRO_COL_ESPECIALIDAD");
                    AgregarColumna_883SC("Telefono_883SC", "MAESTRO_COL_TELEFONO");
                    AgregarColumna_883SC("Direccion_883SC", "MAESTRO_COL_DIRECCION");
                    AgregarColumna_883SC("Margen_883SC", "MAESTRO_COL_MARGEN", false, "N2");
                    AgregarColumna_883SC("Observaciones_883SC", "MAESTRO_COL_OBSERVACIONES");
                    AgregarColumna_883SC("Activo_883SC", "MAESTRO_COL_ACTIVO", true);
                    break;
            }
        }

        private void CargarDatos_883SC()
        {
            try
            {
                switch (tipo_883SC)
                {
                    case TipoMaestro_883SC.Usuarios:
                        dgvMaestro.DataSource = new UsuarioBLL_883SC().ListarUsuarios_883SC();
                        break;
                    case TipoMaestro_883SC.Clientes:
                        dgvMaestro.DataSource = new ClienteBLL_883SC().ListarClientes_883SC();
                        break;
                    case TipoMaestro_883SC.Productos:
                        dgvMaestro.DataSource = new ProductoBLL_883SC().ListarProductos_883SC();
                        break;
                    default:
                        dgvMaestro.DataSource = new ProveedorBLL_883SC().ListarProveedores_883SC();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Traducir_883SC("COMUN_ATENCION"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
