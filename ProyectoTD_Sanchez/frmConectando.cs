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

        //Se puede llamar desde cualquier hilo
        public void CerrarAviso_883SC()
        {
            if (IsDisposed || !IsHandleCreated) { return; }
            if (InvokeRequired) { BeginInvoke(new Action(Close)); }
            else { Close(); }
        }
    }
}
