using System.Collections.Generic;

namespace Entidad_BE
{
    /// Resultado de importar una lista de precios (CUN-007)
    public class ResumenImportacionBE_883SC
    {
        //Items guardados: nuevos mas actualizados
        private int _importados_883SC;
        public int Importados_883SC
        {
            get { return _importados_883SC; }
            set { _importados_883SC = value; }
        }

        //Productos vinculados cuyo precio de venta cambio de valor
        private int _preciosVentaActualizados_883SC;
        public int PreciosVentaActualizados_883SC
        {
            get { return _preciosVentaActualizados_883SC; }
            set { _preciosVentaActualizados_883SC = value; }
        }

        //Items del proveedor sin producto vinculado (despues de la importacion)
        private int _pendientes_883SC;
        public int Pendientes_883SC
        {
            get { return _pendientes_883SC; }
            set { _pendientes_883SC = value; }
        }

        private List<FilaRechazadaBE_883SC> _rechazadas_883SC = new List<FilaRechazadaBE_883SC>();
        public List<FilaRechazadaBE_883SC> Rechazadas_883SC
        {
            get { return _rechazadas_883SC; }
            set { _rechazadas_883SC = value; }
        }
    }
}
