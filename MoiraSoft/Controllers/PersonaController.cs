using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.Controllers
{
    /// <summary>
    /// Controlador encargada del Los datos de las Personas del Sistem
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        [Route("perfil/")]
        public async Task<IActionResult> GetPerfil()
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

        [HttpPost]
        [Route("crear/")]
        public async Task<IActionResult> IngresaPersona(PersonaDto persona)
        {
            try
            {
                if (persona == null)
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
        [Route("ingresa/datosContacto/")]
        public async Task<IActionResult> IngresaDatosContacto(PersonaContactoDto datos)
        {
            try
            {
                if (datos == null)
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

        [HttpGet]
        [Route("/persona/cargo")]
        public async Task<IActionResult> ObtenerPersonaCargo(int rut)
        {
            try
            {
                if (rut == 0)
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

        [HttpGet]
        [Route("/cargo")]
        public async Task<IActionResult> ObtenerCargo()
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
    }
}