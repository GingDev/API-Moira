using MoiraSoftDatos.Entities;
using MoiraSoftNegocio.DataTransferObject;
using System.Collections.Generic;
using System.Linq;

namespace MoiraSoftNegocio.BusinessMapper
{
    public static class TurnoMapper
    {
        public static InfoTurnoDto InfoTurnoToDto(InfoTurnoEntity entity)
        {
            return new InfoTurnoDto
            {
                PersonaId = entity.PersonaId,
                TurnoId = entity.TurnoId,
                Nombre = entity.Nombre,
                FechaInicioTurno = entity.FechaInicioTurno,
                FechaTerminoTurno = entity.FechaTerminoTurno
            };
        }

        public static List<InfoTurnoDto> InfoTurnoToDto(List<InfoTurnoEntity> collEntity)
        {
            return collEntity.Select(c => InfoTurnoToDto(c)).ToList();
        }

        public static TurnoEntity TurnoToEntity(TurnoDto dto)
        {
            return new TurnoEntity
            {
                FechaFinTurno = dto.FechaFinRegistro,
                FechaInicioTurno = dto.FechaInicioRegistro,
                FechaRegistro = dto.FechaRegistro,
                PersonaId = dto.PersonaId,
                TipoRegistro = dto.TipoRegistro,
                TurnoId = dto.TurnoId
            };
        }

        public static TurnoDto TurnoToDto(TurnoEntity entity)
        {
            return new TurnoDto
            {
                TurnoId = entity.TurnoId,
                TipoRegistro = entity.TipoRegistro,
                RegistroTurnoId = entity.RegistroTurnoId,
                FechaFinRegistro = entity.FechaFinTurno,
                FechaInicioRegistro = entity.FechaInicioTurno,
                FechaRegistro = entity.FechaRegistro,
                PersonaId = entity.PersonaId
            };
        }

    }
}
