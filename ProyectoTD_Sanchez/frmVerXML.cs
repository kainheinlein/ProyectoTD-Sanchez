using Negocio_BLL;
using Servicios;
using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    public partial class frmVerXML_883SC : Form, IObservadorIdioma_883SC
    {
        public frmVerXML_883SC(string contenido)
        {
            InitializeComponent();
            txtContenido.Text = contenido;
        }

        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        public void ActualizarTextos_883SC()
        {
            this.Text = gestorIdioma_883SC.Traducir_883SC("CLI_SER_VER_TITULO");
            btnCerrar.Text = gestorIdioma_883SC.Traducir_883SC("COMUN_SALIR");
        }

        private void frmVerXML_Load_883SC(object sender, EventArgs e)
        {
            txtContenido.SelectionStart = 0;
            txtContenido.SelectionLength = 0;
            gestorIdioma_883SC.Suscribir_883SC(this);
            this.FormClosed += (s, ev) => gestorIdioma_883SC.Desuscribir_883SC(this);
        }

        private void btnCerrar_Click_883SC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
