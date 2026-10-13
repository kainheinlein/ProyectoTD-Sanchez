using Acceso_DAL;
using Entidad_BE;
using System;
using System.Collections.Generic;

namespace Negocio_BLL
{
    public class CarritoBLL_883SC
    {
        MP_Carrito_883SC mpCarrito_883SC = new MP_Carrito_883SC();
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        public DetalleCarritoBE_883SC CrearDetalleCarrito_883SC(ProductoBE_883SC producto, int cantidad)
        {
            DetalleCarritoBE_883SC detalle = new DetalleCarritoBE_883SC();
            detalle.Producto_883SC = producto;
            detalle.Cantidad_883SC = cantidad;
            detalle.PrecioUnitario_883SC = producto.Precio_883SC;
            return detalle;
        }

        /// <summary>
        /// Agrega un producto al carrito en progreso. Si el producto ya esta, se
        /// suman las cantidades sobre la misma linea (Detalle_Carrito tiene PK
        /// (IDCarrito, Codigo): un producto no puede aparecer dos veces). El stock
        /// se valida contra la cantidad acumulada; si no alcanza no se modifica nada.
        /// </summary>
        public void AgregarAlCarrito_883SC(List<DetalleCarritoBE_883SC> carrito, ProductoBE_883SC producto, int cantidad)
        {
            DetalleCarritoBE_883SC existente = null;
            foreach (DetalleCarritoBE_883SC linea in carrito)
            {
                if (linea.Producto_883SC.Codigo_883SC == producto.Codigo_883SC)
                {
                    existente = linea;
                    break;
                }
            }

            int total = cantidad + (existente == null ? 0 : existente.Cantidad_883SC);
            if (total > producto.Stock_883SC)
            {
                throw new InvalidOperationException(gestorIdioma_883SC.Traducir_883SC("PROD_MSG_STOCK_INSUFICIENTE"));
            }

            if (existente != null)
            {
                //El precio congelado de la linea original no se toca
                existente.Cantidad_883SC = total;
            }
            else
            {
                carrito.Add(CrearDetalleCarrito_883SC(producto, cantidad));
            }
        }

        /// Arma el carrito, lo persiste y le asigna el Id que genero la base.
        /// No permite creacion de carritos vacios ni con productos repetidos.
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

        public List<CarritoBE_883SC> ListarCarritosPendientes_883SC()
        {
            return mpCarrito_883SC.ListarCarritosPendientes_883SC();
        }

        public CarritoBE_883SC ObtenerCarritoCompleto_883SC(int idCarrito)
        {
            return mpCarrito_883SC.ObtenerCarritoCompleto_883SC(idCarrito);
        }

        //Debido a que Detalle_Carrito tiene PK compuesta (IDCarrito, Codigo), no puede haber
        //productos repetidos en el carrito.Se valida antes de intentar persistir el carrito.
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
