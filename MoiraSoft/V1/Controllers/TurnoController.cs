using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.V1.Controllers
{
    /// <summary>
    /// Controlador encargada de los turnos de los trabajadores
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TurnoController : ControllerBase
    {
        [HttpGet]
        [Route("TipoTurno/")]
        public async Task<IActionResult> ObtenerTipoTurno()
        {
            try
            {
                await Task.Delay(10);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("crear/")]
        public async Task<IActionResult> CrearTurno(TurnoDto turno)
        {
            try
            {
                if (turno == null)
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