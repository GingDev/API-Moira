using MoiraSoftDatos.IRepository;
using MoiraSoftNegocio.BusinessExtension;
using MoiraSoftNegocio.BusinessInterfaces;
using MoiraSoftNegocio.BusinessMapper;
using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessImplementation
{
    public class LoginImplSvc : ILoginSvc
    {
        private readonly ILoginRepository _loginRepository;

        public LoginImplSvc(ILoginRepository iLoginRepository)
        {
            _loginRepository = iLoginRepository;
        }

        public async Task<RespuestaDto<Login>> GetLogin(string user, string pass)
        {
            var login = new Login();
            try
            {
                await Task.Delay(10);

                var datos = _loginRepository.GetLogin(user, pass);

                if (datos.Result != null)
                {
                    login = LoginMapper.EntityToLogin(datos.Result);
                }
            }
            catch (Exception ex)
            {
                return MensajeRespuesta.CrearMensajeRespuesta(login, ex.Message, false);
            }

            return MensajeRespuesta.CrearMensajeRespuesta(login, string.Empty, true);
        }

        public async Task<RespuestaDto<Login>> CreateLogin(Login login)
        {
            var loginResult = new Login();
            try
            {
                await Task.Delay(10);

                var resultado = _loginRepository.CreateLogin(LoginMapper.LoginToEntity(login));

                if (resultado.Result != null)
                {
                    loginResult = LoginMapper.EntityToLogin(resultado.Result);
                }

            }
            catch (Exception ex)
            {
                return MensajeRespuesta.CrearMensajeRespuesta(loginResult, ex.Message, false);
            }

            return MensajeRespuesta.CrearMensajeRespuesta(loginResult, string.Empty, true);
        }

    }
}
