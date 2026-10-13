using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidad_BE
{
    public class FacturaBE_883SC
    {
        //IdFactura generado en DB (MAX+1 en el SP), se asigna al persistir la factura
        private int _idFactura_883SC;
        public int IdFactura_883SC
        {
            get { return _idFactura_883SC; }
        }

        private ClienteBE_883SC _cliente_883SC;
        public ClienteBE_883SC Cliente_883SC
        {
            get { return _cliente_883SC; }
            set { _cliente_883SC = value; }
        }

        private MetodoPagoBE_883SC _metodoPago_883SC;
        public MetodoPagoBE_883SC MetodoPago_883SC
        {
            get { return _metodoPago_883SC; }
            set { _metodoPago_883SC = value; }
        }

        //Null cuando el metodo no requiere validacion bancaria (Efectivo/Transferencia)
        private string _codigoAutorizacion_883SC;
        public string CodigoAutorizacion_883SC
        {
            get { return _codigoAutorizacion_883SC; }
            set { _codigoAutorizacion_883SC = value; }
        }

        private DateTime _fechaVenta_883SC;
        public DateTime FechaVenta_883SC
        {
            get { return _fechaVenta_883SC; }
            set { _fechaVenta_883SC = value; }
        }

        private int _idCarrito_883SC;
        public int IdCarrito_883SC
        {
            get { return _idCarrito_883SC; }
            set { _idCarrito_883SC = value; }
        }

        private int _idUsuario_883SC;
        public int IdUsuario_883SC
        {
            get { return _idUsuario_883SC; }
            set { _idUsuario_883SC = value; }
        }

        private List<DetalleFacturaBE_883SC> _detalle_883SC = new List<DetalleFacturaBE_883SC>();
        public List<DetalleFacturaBE_883SC> Detalle_883SC
        {
            get { return _detalle_883SC; }
            set { _detalle_883SC = value; }
        }

        public decimal PrecioTotal_883SC
        {
            get
            {
                if (_detalle_883SC == null) { return 0; }
                return _detalle_883SC.Sum(d => d.Cantidad_883SC * d.PrecioUnitario_883SC);
            }
        }

        public void AsignarId_883SC(int id)
        {
            _idFactura_883SC = id;
        }

        public static FacturaBE_883SC CrearFactura_883SC(ClienteBE_883SC cliente, List<DetalleFacturaBE_883SC> detalle,
            int idCarrito, MetodoPagoBE_883SC metodoPago, string codigoAutorizacion)
        {
            FacturaBE_883SC factura = new FacturaBE_883SC();
            factura.Cliente_883SC = cliente;
            factura.Detalle_883SC = detalle;
            factura.IdCarrito_883SC = idCarrito;
            factura.MetodoPago_883SC = metodoPago;
            factura.CodigoAutorizacion_883SC = codigoAutorizacion;
            factura.FechaVenta_883SC = DateTime.Now;
            return factura;
        }
    }
}
