using System;
using System.Collections.Generic;
using System.Linq;

namespace Entidad_BE
{
    public class CarritoBE_883SC
    {
        //idCarrito generado en DB (MAX+1 en el SP), se asigna al persistir el carrito

        private int _idCarrito_883SC;
        public int IdCarrito_883SC
        {
            get { return _idCarrito_883SC; }
        }

        private string _nombre_883SC;
        public string Nombre_883SC
        {
            get { return _nombre_883SC; }
            set { _nombre_883SC = value; }
        }

        private DateTime _fechaCreacion_883SC;
        public DateTime FechaCreacion_883SC
        {
            get { return _fechaCreacion_883SC; }
            set { _fechaCreacion_883SC = value; }
        }

        private List<DetalleCarritoBE_883SC> _detalle_883SC = new List<DetalleCarritoBE_883SC>();
        public List<DetalleCarritoBE_883SC> Detalle_883SC
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
            _idCarrito_883SC = id;
        }

        public static CarritoBE_883SC CrearCarrito_883SC(List<DetalleCarritoBE_883SC> detalle, string nombre)
        {
            CarritoBE_883SC carrito = new CarritoBE_883SC();
            carrito.Detalle_883SC = detalle;
            carrito.Nombre_883SC = nombre;
            carrito.FechaCreacion_883SC = DateTime.Now;
            return carrito;
        }
    }
}
