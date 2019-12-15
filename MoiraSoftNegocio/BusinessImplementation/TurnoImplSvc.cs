﻿using MoiraSoftDatos.IRepository;
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
    }
}