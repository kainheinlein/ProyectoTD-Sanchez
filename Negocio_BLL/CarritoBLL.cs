using Acceso_DAL;
using Entidad_BE;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class CarritoBLL_883SC
    {
        MP_Carrito_883SC mpCarrito_883SC = new MP_Carrito_883SC();

        public DetalleCarritoBE_883SC CrearDetalleCarrito_883SC(ProductoBE_883SC producto, int cantidad)
        {
            DetalleCarritoBE_883SC detalle = new DetalleCarritoBE_883SC();
            detalle.Producto_883SC = producto;
            detalle.Cantidad_883SC = cantidad;
            detalle.PrecioUnitario_883SC = producto.Precio_883SC;
            return detalle;
        }

        /// <summary>
        /// Arma el carrito, lo persiste y le asigna el Id que genero la base.
        /// Las validaciones corren ANTES de tocar la base: nunca se persiste
        /// un carrito sin lineas ni con un producto repetido.
        /// </summary>
        public CarritoBE_883SC CrearCarrito_883SC(List<DetalleCarritoBE_883SC> detalle, string nombre)
        {
            if (detalle == null || detalle.Count == 0)
            {
                throw new InvalidOperationException("No se puede crear un carrito sin productos");
            }
            ValidarSinRepetidos_883SC(detalle);

            CarritoBE_883SC carrito = CarritoBE_883SC.CrearCarrito_883SC(detalle, nombre);
            int id = mpCarrito_883SC.GuardarCarrito_883SC(carrito);
            carrito.AsignarId_883SC(id);
            return carrito;
        }

        //Detalle_Carrito tiene PK compuesta (IDCarrito, Codigo): un mismo producto
        //no puede aparecer dos veces en el carrito. Se avisa con un mensaje claro
        //en lugar de dejar que la base devuelva una violacion de clave primaria.
        private void ValidarSinRepetidos_883SC(List<DetalleCarritoBE_883SC> detalle)
        {
            List<string> vistos = new List<string>();
            foreach (DetalleCarritoBE_883SC linea in detalle)
            {
                string codigo = linea.Producto_883SC.Codigo_883SC;
                if (vistos.Contains(codigo))
                {
                    throw new InvalidOperationException("El producto " + codigo + " esta repetido en el carrito");
                }
                vistos.Add(codigo);
            }
        }
    }
}
