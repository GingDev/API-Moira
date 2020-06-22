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
        Task<ListRespuestaDto<RegistroAnormalDto>> GetRegistroAnormal();
        Task<ListRespuestaDto<TrabajadorDto>> GetTrabajadores();
        Task<RespuestaDto<InfoPersonaLoginDto>> GetInfoPersonaLogin(int loginId);
        Task<RespuestaDto<bool>> AsociarPersonaCargo(PersonaCargoDto persona);
    }
}
