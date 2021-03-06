﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.BusinessInterfaces;
using MoiraSoftNegocio.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace MoiraSoft.V1.Controllers
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
        private readonly IPersonaSvc _persona;

        public PersonaController(IPersonaSvc ipersona)
        {
            _persona = ipersona;
        }

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
        [HttpGet]
        [Route("obtener/infoPersonaTurno")]
        public async Task<IActionResult> ObtenerInfoPersonaTurno()
        {
            try
            {
                var result = await _persona.GetInfoPersonaTurnoList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("obtener/infoRegistroAnormal")]
        public async Task<IActionResult> ObtenerInfoRegistroAnormal()
        {
            try
            {
                var result = await _persona.GetRegistroAnormal();
                return Ok(result);
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
                var result = await _persona.CrearPersona(persona);
                return Ok(result);
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

        [HttpPost]
        [Route("asocia/")]
        public async Task<IActionResult> AsociaPersonaCargo(PersonaCargoDto personaCargo)
        {
            try
            {
                if (personaCargo == null)
                {
                    return BadRequest("Solicitud Inválida");
                }
                var result = await _persona.AsociarPersonaCargo(personaCargo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        #endregion

        #region [Datos de Contacto]

        [HttpGet]
        [Route("datosContacto/obtener/{personaId}")]
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
        [Route("personaCargo/{rut}")]
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
        [Route("cargo/obtener")]
        public async Task<IActionResult> ObtenerCargo()
        {
            try
            {
                var result = await _persona.GetCargos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("trabajadores/obtener")]
        public async Task<IActionResult> ObtenerTrabajadores()
        {
            try
            {
                var result = await _persona.GetTrabajadores();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("InfoPersonaLogin/obtener/{loginId}")]
        public async Task<IActionResult> ObtenerInfoPersonaLogin(int loginId)
        {
            try
            {
                var result = await _persona.GetInfoPersonaLogin(loginId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

    }
}