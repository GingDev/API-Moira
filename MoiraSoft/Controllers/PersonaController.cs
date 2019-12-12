using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.Controllers
{
    /// <summary>
    /// Controlador encargada del Los datos de las Personas del Sistema
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

        #region [Persona]

        [HttpGet]
        [Route("obtener/")]
        public async Task<IActionResult> ObtenerPersona(int loginId)
        {
            try
            {
                if (loginId == 0)
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

        [HttpPut]
        [Route("modifica/")]
        public async Task<IActionResult> ModificarPersona(PersonaDto persona)
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

        [HttpDelete]
        [Route("elimina/")]
        public async Task<IActionResult> EliminarPersona(PersonaDto persona)
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

        #endregion

        #region [Datos de Contacto]

        [HttpGet]
        [Route("obtener/datosContacto/{personaId}")]
        public async Task<IActionResult> ObtenerDatosContacto(int personaId)
        {
            try
            {
                if (personaId == 0)
                {
                    return BadRequest("");
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

        [HttpPut]
        [Route("modifica/datosContacto/")]
        public async Task<IActionResult> ModificarDatosContacto(PersonaContactoDto datos)
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

        [HttpDelete]
        [Route("elimina/datosContacto/")]
        public async Task<IActionResult> EliminarDatosContacto(PersonaContactoDto datos)
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

        #endregion

        [HttpGet]
        [Route("persona/cargo/{rut}")]
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