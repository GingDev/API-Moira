using MoiraSoftDatos.Entities;
using MoiraSoftDatos.IRepository;
using System;
using System.Threading.Tasks;

namespace MoiraSoftDatos.Repository
{
    public class LoginRepository : ILoginRepository
    {
        //  private static string conStr = ConnectionServicesOption.GetConnectionString();

        public async Task<LoginEntity> GetLogin(string user, string pass)
        {
            var login = new LoginEntity
            {
                LoginId = 1,
                Estado = true,
                Usuario = "Ging",
                Password = "Oe"
            };

            await Task.Delay(10);

            if (user == "Ging" && pass == "Oe")
            {
                return login;
            }
            else
            {
                return new LoginEntity { };
            }
        }

        public async Task<LoginEntity> CreateLogin(LoginEntity login)
        {
            await Task.Delay(10);
            Random random = new Random();
            login.LoginId = random.Next(0, 100);

            return login;
        }
    }
}
