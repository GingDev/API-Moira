using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessInterfaces
{
    public interface IPersonaSvc
    {
        Task<ListRespuestaDto<CargoDto>> GetCargos();
        Task<RespuestaDto<PersonaDto>> CrearPersona(PersonaDto persona);
        Task<ListRespuestaDto<PersonaInfoDto>> GetInfoPersonaTurnoList();
    }
}
