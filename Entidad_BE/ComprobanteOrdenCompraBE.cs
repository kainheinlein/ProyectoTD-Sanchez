using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidad_BE
{
    //Datos del comprobante de una orden de compra enviada. Solo datos: el armado del texto es de la BLL.
    public class ComprobanteOrdenCompraBE_883SC
    {
        //Es el IdOrdenCompra de la orden, se asigna una unica vez al leerla
        private int _idOrdenCompra_883SC;
        public int IdOrdenCompra_883SC
        {
            get { return _idOrdenCompra_883SC; }
        }

        public void AsignarId_883SC(int id)
        {
            _idOrdenCompra_883SC = id;
        }

        private string _proveedor_883SC;
        public string Proveedor_883SC
        {
            get { return _proveedor_883SC; }
            set { _proveedor_883SC = value; }
        }

        private EstadoOrdenCompra_883SC _estado_883SC;
        public EstadoOrdenCompra_883SC Estado_883SC
        {
            get { return _estado_883SC; }
            set { _estado_883SC = value; }
        }

        private DateTime _fechaCreacion_883SC;
        public DateTime FechaCreacion_883SC
        {
            get { return _fechaCreacion_883SC; }
            set { _fechaCreacion_883SC = value; }
        }

        //Nombre de usuario de quien genero la orden
        private string _usuarioCreacion_883SC;
        public string UsuarioCreacion_883SC
        {
            get { return _usuarioCreacion_883SC; }
            set { _usuarioCreacion_883SC = value; }
        }

        //Nombre de usuario de quien autorizo (null si no hay dato)
        private string _usuarioDecision_883SC;
        public string UsuarioDecision_883SC
        {
            get { return _usuarioDecision_883SC; }
            set { _usuarioDecision_883SC = value; }
        }

        private DateTime? _fechaDecision_883SC;
        public DateTime? FechaDecision_883SC
        {
            get { return _fechaDecision_883SC; }
            set { _fechaDecision_883SC = value; }
        }

        private DateTime? _fechaEnvio_883SC;
        public DateTime? FechaEnvio_883SC
        {
            get { return _fechaEnvio_883SC; }
            set { _fechaEnvio_883SC = value; }
        }

        private List<LineaComprobanteOCBE_883SC> _lineas_883SC = new List<LineaComprobanteOCBE_883SC>();
        public List<LineaComprobanteOCBE_883SC> Lineas_883SC
        {
            get { return _lineas_883SC; }
            set { _lineas_883SC = value; }
        }

        public decimal PrecioTotal_883SC
        {
            get
            {
                if (_lineas_883SC == null) { return 0; }
                return _lineas_883SC.Sum(l => l.Subtotal_883SC);
            }
        }
    }
}
