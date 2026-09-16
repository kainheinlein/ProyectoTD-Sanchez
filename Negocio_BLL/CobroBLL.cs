using Entidad_BE;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Negocio_BLL
{
    public class CobroBLL_883SC
    {
        GestorDeIdioma_883SC gestorIdioma_883SC = GestorDeIdioma_883SC.GetInstance_883SC;

        public string Cobrar_883SC(MetodoPagoBE_883SC metodoPago, decimal monto,
            List<string> datos, Func<decimal, bool> simulacionEntidadBancaria)
        {
            if (metodoPago.Validacion_883SC)
            {
                bool aprobado = simulacionEntidadBancaria(monto);
                if (!aprobado)
                    throw new PagoRechazadoException_883SC("El pago fue rechazado por la entidad bancaria.");
                return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            }
            return null;
        }

        //Lanza ArgumentException con el mensaje traducido del primer dato invalido
        public void ValidarDatosTarjeta_883SC(string numero, string titular, string dni, string vencimiento, string cvv)
        {
            if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(titular) ||
                string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(vencimiento) ||
                string.IsNullOrWhiteSpace(cvv))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_MSG_TARJETA_INCOMPLETA"));
            }

            if (numero.Length < 13 || numero.Length > 19 || !SoloDigitos_883SC(numero))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_ERR_NUMERO"));
            }

            if (!SoloDigitos_883SC(dni))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_ERR_DNI"));
            }

            DateTime mesVencimiento;
            if (!DateTime.TryParseExact(vencimiento, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out mesVencimiento))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_ERR_VENCIMIENTO_FORMATO"));
            }

            //La tarjeta vale hasta el ultimo dia del mes impreso: vence al arrancar el mes siguiente
            if (mesVencimiento.AddMonths(1) <= DateTime.Now)
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_ERR_VENCIDA"));
            }

            if (cvv.Length < 3 || !SoloDigitos_883SC(cvv))
            {
                throw new ArgumentException(gestorIdioma_883SC.Traducir_883SC("COBRO_ERR_CVV"));
            }
        }

        private bool SoloDigitos_883SC(string texto)
        {
            foreach (char c in texto)
            {
                if (c < '0' || c > '9') { return false; }
            }
            return true;
        }
    }
}
