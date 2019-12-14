namespace MoiraSoftNegocio.Respuesta
{
    public class RespuestaDto<T> : RespuestaEstandarDto
    {
        public T Data { get; set; }
    }
}
