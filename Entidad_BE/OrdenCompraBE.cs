using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidad_BE
{
    public class OrdenCompraBE_883SC
    {
        //IdOrdenCompra generado en DB (MAX+1 en el SP), se asigna al persistir la orden

        private int _idOrdenCompra_883SC;
        public int IdOrdenCompra_883SC
        {
            get { return _idOrdenCompra_883SC; }
        }

        private ProveedorBE_883SC _proveedor_883SC;
        public ProveedorBE_883SC Proveedor_883SC
        {
            get { return _proveedor_883SC; }
            set { _proveedor_883SC = value; }
        }

        private EstadoOrdenCompra_883SC _estado_883SC = EstadoOrdenCompra_883SC.Pendiente;
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

        private int _idUsuarioCreacion_883SC;
        public int IdUsuarioCreacion_883SC
        {
            get { return _idUsuarioCreacion_883SC; }
            set { _idUsuarioCreacion_883SC = value; }
        }

        //Datos de la autorizacion/rechazo (null mientras esta pendiente)
        private int? _idUsuarioDecision_883SC;
        public int? IdUsuarioDecision_883SC
        {
            get { return _idUsuarioDecision_883SC; }
            set { _idUsuarioDecision_883SC = value; }
        }

        private DateTime? _fechaDecision_883SC;
        public DateTime? FechaDecision_883SC
        {
            get { return _fechaDecision_883SC; }
            set { _fechaDecision_883SC = value; }
        }

        private string _observacionesDecision_883SC;
        public string ObservacionesDecision_883SC
        {
            get { return _observacionesDecision_883SC; }
            set { _observacionesDecision_883SC = value; }
        }

        private DateTime? _fechaEnvio_883SC;
        public DateTime? FechaEnvio_883SC
        {
            get { return _fechaEnvio_883SC; }
            set { _fechaEnvio_883SC = value; }
        }

        private DateTime? _fechaRecepcion_883SC;
        public DateTime? FechaRecepcion_883SC
        {
            get { return _fechaRecepcion_883SC; }
            set { _fechaRecepcion_883SC = value; }
        }

        private string _observacionesRecepcion_883SC;
        public string ObservacionesRecepcion_883SC
        {
            get { return _observacionesRecepcion_883SC; }
            set { _observacionesRecepcion_883SC = value; }
        }

        private List<DetalleOrdenCompraBE_883SC> _detalle_883SC = new List<DetalleOrdenCompraBE_883SC>();
        public List<DetalleOrdenCompraBE_883SC> Detalle_883SC
        {
            get { return _detalle_883SC; }
            set { _detalle_883SC = value; }
        }

        public decimal PrecioTotal_883SC
        {
            get
            {
                if (_detalle_883SC == null) { return 0; }
                return _detalle_883SC.Sum(d => d.Subtotal_883SC);
            }
        }

        public void AsignarId_883SC(int id)
        {
            _idOrdenCompra_883SC = id;
        }
    }
}
