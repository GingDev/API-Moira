using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoiraSoftNegocio.BusinessInterfaces;
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
        private readonly ITurnoSvc _turno;

        public TurnoController(ITurnoSvc iTurno)
        {
            _turno = iTurno;
        }
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

        [HttpPost]
        [Route("crear/")]
        public async Task<IActionResult> CrearTurno(TurnoDto turno)
        {
            try
            {
                if (turno == null)
                {
                    return BadRequest("Solicitud Inválida");
                }

                var result = await _turno.CrearTurno(turno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("InfoTurno/obtener")]
        public async Task<IActionResult> ObtenerInfoTurno()
        {
            try
            {
                var result = await _turno.GetInfoTurno();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("InfoVacaciones/obtener")]
        public async Task<IActionResult> ObtenerInfoVacaciones()
        {
            try
            {
                var result = await _turno.GetInfoVacaciones();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

        [HttpGet]
        [Route("InfoLicencia/obtener")]
        public async Task<IActionResult> ObtenerInfoLicencia()
        {
            try
            {
                var result = await _turno.GetInfoLicencias();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("Ha ocurrido un error: {0}", ex.Message));
            }
        }

    }
}