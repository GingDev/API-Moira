using System.Collections.Generic;

namespace MoiraSoftNegocio.Respuesta
{
    public class ListRespuestaDto<T> : RespuestaEstandarDto
    {
        public List<T> Data { get; set; }
    }
}
