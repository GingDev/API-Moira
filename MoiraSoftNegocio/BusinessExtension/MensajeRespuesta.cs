using MoiraSoftNegocio.Respuesta;
using System.Collections.Generic;

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

        public static ListRespuestaDto<T> CrearMensajeRespuestaList<T>(List<T> data, string descripcionError, bool estado)
        {
            return new ListRespuestaDto<T>()
            {
                Estado = estado,
                Data = data
            };
        }
    }
}
