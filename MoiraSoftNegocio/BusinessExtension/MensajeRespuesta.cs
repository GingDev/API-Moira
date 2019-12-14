using MoiraSoftNegocio.Respuesta;

namespace MoiraSoftNegocio.BusinessExtension
{
    public static class MensajeRespuesta
    {
        public static RespuestaDto<T> CrearMensajeRespuesta<T>(T data, string descripcionError, bool estado)
        {
            return new RespuestaDto<T>()
            {
                Estado = estado,
                Data = data
            };
        }
    }
}
