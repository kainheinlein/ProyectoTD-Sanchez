using System;
using System.Windows.Forms;

namespace TP_SanchezVillaverde
{
    //Aviso del arranque ("Conectando..."). Textos en espanol fijo y sin IObservadorIdioma_883SC: se muestra ANTES de que
    //exista la base, de donde salen las traducciones.
    public partial class frmConectando_883SC : Form
    {
        public frmConectando_883SC()
        {
            InitializeComponent();
        }

        //Se puede llamar desde cualquier hilo
        public void MostrarEtapa_883SC(string texto)
        {
            if (IsDisposed || !IsHandleCreated) { return; }
            if (InvokeRequired) { BeginInvoke(new Action(() => lblEtapa.Text = texto)); }
            else { lblEtapa.Text = texto; }
        }

        //Pregunta si se crea una base nueva y vacia en la instancia alternativa. Se puede llamar desde cualquier hilo:
        //el cuadro se muestra en el hilo de este formulario, por encima de el.
        public bool ConfirmarBaseNueva_883SC(string instanciaConfigurada, string instanciaUsada)
        {
            if (InvokeRequired) { return (bool)Invoke(new Func<string, string, bool>(ConfirmarBaseNueva_883SC), instanciaConfigurada, instanciaUsada); }

            string texto = "La instancia configurada (" + instanciaConfigurada + ") no respondio y en la instancia alternativa (" + instanciaUsada +
                ") no existe la base de datos de la aplicacion.\r\n\r\n" +
                "¿Desea crear una base nueva y vacia en " + instanciaUsada + "?\r\n\r\n" +
                "Si elige No, la aplicacion se cierra sin crear nada. Los datos de la instancia configurada no se modifican.";
            return MessageBox.Show(this, texto, "FerreSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        //Se puede llamar desde cualquier hilo
        public void CerrarAviso_883SC()
        {
            if (IsDisposed || !IsHandleCreated) { return; }
            if (InvokeRequired) { BeginInvoke(new Action(Close)); }
            else { Close(); }
        }
    }
}
