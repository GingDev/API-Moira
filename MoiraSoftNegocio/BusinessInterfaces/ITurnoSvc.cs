using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessInterfaces
{
    public interface ITurnoSvc
    {
        Task<ListRespuestaDto<InfoTurnoDto>> GetInfoTurno();
    }
}
