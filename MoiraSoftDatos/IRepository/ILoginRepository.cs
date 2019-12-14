using MoiraSoftDatos.Entities;
using System.Threading.Tasks;

namespace MoiraSoftDatos.IRepository
{
    public interface ILoginRepository
    {
        Task<LoginEntity> GetLogin(string user, string pass, string connection);
        Task<LoginEntity> CreateLogin(LoginEntity login, string connection);
    }
}
