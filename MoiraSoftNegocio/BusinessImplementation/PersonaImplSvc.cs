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
    public class PersonaImplSvc : IPersonaSvc
    {
        private readonly IPersonaRepository _personaRepository;
        private static string conStr = ConnectionServicesOption.GetConnectionString();

        public PersonaImplSvc(IPersonaRepository iPersonaRepository)
        {
            _personaRepository = iPersonaRepository;
        }

        public async Task<ListRespuestaDto<CargoDto>> GetCargos()
        {
            List<CargoDto> collCargo = new List<CargoDto>();
            try
            {
                var datos = await _personaRepository.GetCargos(conStr);

                if (datos.Count > 0)
                {
                    collCargo = PersonaMapper.CargoToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return MensajeRespuesta.CrearMensajeRespuestaList(collCargo, string.Empty, true);
        }

        public async Task<RespuestaDto<PersonaDto>> CrearPersona(PersonaDto persona)
        {
            PersonaDto DatosPersona = new PersonaDto();

            try
            {
                var datos = await _personaRepository.CrearPersona(PersonaMapper.PersonaToEntity(persona), conStr);

                if (datos != null)
                {
                    DatosPersona = PersonaMapper.PersonaToDto(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return MensajeRespuesta.CrearMensajeRespuesta(DatosPersona, string.Empty, true);

        }

        public async Task<ListRespuestaDto<PersonaInfoDto>> GetInfoPersonaTurnoList()
        {
            List<PersonaInfoDto> collPersonas = new List<PersonaInfoDto>();
            try
            {
                var datos = await _personaRepository.GetInfoPersonaTurno(conStr);

                if (datos.Count > 0)
                {
                    collPersonas = PersonaMapper.PersonaInfoToEntity(datos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            return MensajeRespuesta.CrearMensajeRespuestaList(collPersonas, string.Empty, true);
        }
    }
}