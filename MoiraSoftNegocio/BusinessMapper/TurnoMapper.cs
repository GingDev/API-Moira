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
    }
}
