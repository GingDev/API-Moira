using MoiraSoftDatos.IRepository;
using MoiraSoftNegocio.BusinessExtension;
using MoiraSoftNegocio.BusinessInterfaces;
using MoiraSoftNegocio.BusinessMapper;
using MoiraSoftNegocio.DataTransferObject;
using MoiraSoftNegocio.Respuesta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoiraSoftNegocio.BusinessImplementation
{
    public class TurnoImplSvc : ITurnoSvc
    {
        private readonly ITurnoRepository _turnoRepository;
        private static string conStr = ConnectionServicesOption.GetConnectionString();

        public TurnoImplSvc(ITurnoRepository iTurnoRepository)
        {
            _turnoRepository = iTurnoRepository;
        }
        public async Task<ListRespuestaDto<InfoTurnoDto>> GetInfoTurno()
        {
            List<InfoTurnoDto> collRegistros = new List<InfoTurnoDto>();
            try
            {
                var datos = await _turnoRepository.GetInfoTurno(conStr);

                if (datos.Count > 0)
                {
                    collRegistros = TurnoMapper.InfoTurnoToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return MensajeRespuesta.CrearMensajeRespuestaList(collRegistros, string.Empty, true);
        }

        public async Task<RespuestaDto<TurnoDto>> CrearTurno(TurnoDto turno)
        {
            TurnoDto datosTurno = new TurnoDto();

            try
            {
                var datos = await _turnoRepository.CrearTurno(TurnoMapper.TurnoToEntity(turno), conStr);

                if (datos != null)
                {
                    datosTurno = TurnoMapper.TurnoToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return MensajeRespuesta.CrearMensajeRespuesta(datosTurno, string.Empty, true);

        }

        public async Task<ListRespuestaDto<InfoTurnoDto>> GetInfoVacaciones()
        {
            List<InfoTurnoDto> collRegistros = new List<InfoTurnoDto>();
            try
            {
                var datos = await _turnoRepository.GetInfoVacaciones(conStr);

                if (datos.Count > 0)
                {
                    collRegistros = TurnoMapper.InfoTurnoToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return MensajeRespuesta.CrearMensajeRespuestaList(collRegistros, string.Empty, true);
        }

        public async Task<ListRespuestaDto<InfoTurnoDto>> GetInfoLicencias()
        {
            List<InfoTurnoDto> collRegistros = new List<InfoTurnoDto>();
            try
            {
                var datos = await _turnoRepository.GetInfoLicencia(conStr);

                if (datos.Count > 0)
                {
                    collRegistros = TurnoMapper.InfoTurnoToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return MensajeRespuesta.CrearMensajeRespuestaList(collRegistros, string.Empty, true);
        }

    }
}
