using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.Controllers
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
        [HttpGet]
        [Route("/{user}/{pass}")]
        public async Task<IActionResult> GetLogin(string user, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    return BadRequest("Solicitud Inválida");
                }

                await Task.Delay(10);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> CreateLogin(Login login)
        {
            try
            {
                if (login == null)
                {
                    return BadRequest("Solicitud Inválida");
                }

                await Task.Delay(10);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }
    }
}
