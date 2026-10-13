using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad_BE
{
    public class EventoBE_883SC
    {
		private int _registro_883SC;

		public int registro_883SC
		{
			get { return _registro_883SC; }
			set { _registro_883SC = value; }
		}

		private string _usuario_883SC;

		public string usuario_883SC
		{
			get { return _usuario_883SC; }
			set { _usuario_883SC = value; }
		}

		private TipoAccion_883SC _accion_883SC;

		public TipoAccion_883SC accion_883SC
		{
			get { return _accion_883SC; }
			set { _accion_883SC = value; }
		}

		private DateTime _fecha_883SC;

		public DateTime fecha_883SC
		{
			get { return _fecha_883SC; }
			set { _fecha_883SC = value; }
		}

		public EventoBE_883SC() { }

		public EventoBE_883SC CrearRegistro_883SC(string[] datos)
		{
			this.registro_883SC = Convert.ToInt32(datos[0]);
			this.usuario_883SC = datos[3];
			this.accion_883SC = (TipoAccion_883SC)Convert.ToInt32(datos[1]);
			this.fecha_883SC = Convert.ToDateTime(datos[2]);
			return this;
		}
	}
}
