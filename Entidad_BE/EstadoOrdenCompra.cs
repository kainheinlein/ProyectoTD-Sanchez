namespace Entidad_BE
{
    //Pendiente -> Autorizada/Rechazada; Autorizada -> EnEjecucion -> Recibida.
    //En la base se guarda el nombre (columna OrdenCompra.Estado, con CHECK).
    public enum EstadoOrdenCompra_883SC
    {
        Pendiente,
        Autorizada,
        Rechazada,
        EnEjecucion,
        Recibida
    }
}
