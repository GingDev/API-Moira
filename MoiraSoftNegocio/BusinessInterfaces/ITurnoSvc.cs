using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessInterfaces
{
    public interface ITurnoSvc
    {
        Task<ListRespuestaDto<InfoTurnoDto>> GetInfoTurno();
        Task<RespuestaDto<TurnoDto>> CrearTurno(TurnoDto turno);
    }
}
