using MoiraSoftDatos.Entities;
using MoiraSoftNegocio.DataTransferObject;

namespace MoiraSoftNegocio.BusinessMapper
{
    public static class LoginMapper
    {
        public static LoginEntity LoginToEntity(Login login)
        {
            return new LoginEntity
            {
                Estado = login.Estado,
                LoginId = login.LoginId,
                Password = login.Password,
                Usuario = login.Usuario
            };
        }

        public static Login EntityToLogin(LoginEntity entity)
        {
            return new Login
            {
                Estado = entity.Estado,
                Usuario = entity.Usuario,
                LoginId = entity.LoginId,
                Password = entity.Password
            };
        }
    }
}
