using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessInterfaces
{
    public interface ILoginSvc
    {
        Task<RespuestaDto<Login>> GetLogin(string user, string pass);
        Task<RespuestaDto<Login>> CreateLogin(Login login);
    }
}
