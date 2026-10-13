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

namespace ProyectoCampo_JuanFer
{
    public partial class ucAlfaNum_883SC : UserControl
    {
        public ucAlfaNum_883SC()
        {
            InitializeComponent();
        }

        private static string patron_883SC = @"^[A-Za-z0-9\s]+$";

        private bool _ok_883SC;

        public bool ok_883SC
        {
            get { return _ok_883SC; }
            set { _ok_883SC = value; }
        }

        private string _texto_883SC;

        public string texto_883SC
        {
            get { return _texto_883SC; }
            set { _texto_883SC = txtTexto.Text; }
        }

        private bool _isPass_883SC;

        public bool isPass_883SC
        {
            get { return _isPass_883SC; }
            set { _isPass_883SC = value; }
        }

        public Button boton_883SC;


        private void ucUsuario_Load_883SC(object sender, EventArgs e)
        {
            txtTexto.Clear();
            ptxtTexto.BackColor = Color.DimGray;
            ok_883SC = false;
            texto_883SC = "";
            isPass_883SC = false;
        }

        private void txtTexto_Leave_883SC(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                texto_883SC = txtTexto.Text;
                if(Regex.IsMatch(texto_883SC, patron_883SC))
                {

                    ok_883SC = true;
                    ptxtTexto.BackColor = Color.DimGray;
                }
                else
                {
                    ptxtTexto.BackColor = Color.Red;
                    ok_883SC = false;
                }
            }
            else
            {
                ptxtTexto.BackColor = Color.Red;
                texto_883SC = "";
                ok_883SC = false;
            }
        }

        public void Limpiar_883SC()
        {
            txtTexto.Clear();
        }

        public void Enfocar_883SC()
        {
            txtTexto.Focus();
        }

        public void Hide_883SC(bool pass)
        {
            if (pass) { isPass_883SC = true; txtTexto.UseSystemPasswordChar = true; }
        }

        public void txtContra_KeyPress_883SC(object sender, KeyPressEventArgs e)
        //btn Iniciar al presion enter en campo Contraseña
        {
            if (isPass_883SC)
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    boton_883SC.PerformClick();
                }
            }
        }
    }
}
