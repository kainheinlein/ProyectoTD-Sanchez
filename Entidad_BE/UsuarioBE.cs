using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public class UsuarioBE_883SC : IVerificable_883SC
    {
        private int _cod_883SC;

        public int cod_883SC
        {
            get { return _cod_883SC; }
            set { _cod_883SC = value; }
        }

        private string _nomb_883SC;

        public string nomb_883SC
        {
            get { return _nomb_883SC; }
            set { _nomb_883SC = value; }
        }

        private string _ape_883SC;

        public string ape_883SC
        {
            get { return _ape_883SC; }
            set { _ape_883SC = value; }
        }

        private int _dni_883SC;

        public int dni_883SC
        {
            get { return _dni_883SC; }
            set { _dni_883SC = value; }
        }

        private string _user_883SC;

        public string user_883SC
        {
            get { return _user_883SC; }
            set { _user_883SC = value; }
        }

        private string _pass_883SC;

        public string pass_883SC
        {
            get { return _pass_883SC; }
            set { _pass_883SC = value; }
        }

        private string _rol_883SC;

        public string rol_883SC
        {
            get { return _rol_883SC; }
            set { _rol_883SC = value; }
        }

        private string _dir_883SC;

        public string dir_883SC
        {
            get { return _dir_883SC; }
            set { _dir_883SC = value; }
        }

        private string _tel_883SC;

        public string tel_883SC
        {
            get { return _tel_883SC; }
            set { _tel_883SC = value; }
        }

        private string _email_883SC;

        public string email_883SC
        {
            get { return _email_883SC; }
            set { _email_883SC = value; }
        }

        private Boolean _estado_883SC;

        public Boolean estado_883SC
        {
            get { return _estado_883SC; }
            set { _estado_883SC = value; }
        }

        private Boolean _bloq_883SC;

        public Boolean bloq_883SC
        {
            get { return _bloq_883SC; }
            set { _bloq_883SC = value; }
        }

        private string _dvh_883SC;

        public string dvh_883SC
        {
            get { return _dvh_883SC; }
            set { _dvh_883SC = value; }
        }

        public string digito_883SC => _dvh_883SC;

        public UsuarioBE_883SC() { }

        public UsuarioBE_883SC CrearUsuario_883SC(string[] datos)
        {
            this.cod_883SC = Convert.ToInt32(datos[0]);
            this.dni_883SC = Convert.ToInt32(datos[3]);
            this.nomb_883SC = datos[1];
            this.ape_883SC = datos[2];
            this.user_883SC = datos[4];
            this.rol_883SC = datos[6];
            this.pass_883SC = datos[5];
            this.dir_883SC = datos[7];
            this.tel_883SC = (datos[8]);
            this.email_883SC = datos[9];
            this.estado_883SC = Convert.ToBoolean(datos[10]);
            this.bloq_883SC = Convert.ToBoolean(datos[11]);
            this.dvh_883SC = datos[12];
            return this;
        }

        public string ObtenerCamposDV_883SC()
        {
            return string.Join("|",
                cod_883SC,
                dni_883SC,
                nomb_883SC,
                ape_883SC,
                user_883SC,
                rol_883SC,
                pass_883SC,
                dir_883SC,
                tel_883SC,
                email_883SC,
                estado_883SC,
                bloq_883SC);
        }
    }
}
