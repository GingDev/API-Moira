using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.BusinessInterfaces;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.V1.Controllers
{
    /// <summary>
    /// Controlador encargada del Login de Usuarios
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginSvc _login;

        public LoginController(ILoginSvc iLoginSvc)
        {
            _login = iLoginSvc;
        }

        [HttpGet]
        [Route("ingreso/{user}/{pass}")]
        public async Task<IActionResult> GetLogin(string user, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    return BadRequest("Solicitud Inválida");
                }

                var result = await _login.GetLogin(user, pass);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpPost]
        [Route("crear/")]
        public async Task<IActionResult> CreateLogin(Login login)
        {
            try
            {
                if (login == null)
                {
                    return BadRequest("Solicitud Inválida");
                }

                var result = await _login.CreateLogin(login);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }
    }
}
