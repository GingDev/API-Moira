using MoiraSoftDatos.Entities;
using MoiraSoftNegocio.DataTransferObject;
using System.Collections.Generic;
using System.Linq;

namespace MoiraSoftNegocio.BusinessMapper
{
    public static class PersonaMapper
    {
        public static CargoDto CargoToDto(CargoEntity entity)
        {
            return new CargoDto
            {
                CargoId = entity.CargoId,
                Descripcion = entity.Descripcion,
                Estado = entity.Estado
            };
        }

        public static List<CargoDto> CargoToDto(List<CargoEntity> collEntities)
        {
            return collEntities.Select(c => CargoToDto(c)).ToList();
        }

        public static PersonaEntity PersonaToEntity(PersonaDto dto)
        {
            return new PersonaEntity
            {
                PersonaId = dto.PersonaId,
                LoginId = dto.LoginId,
                PerfilId = dto.PerfilId,
                Rut = dto.Rut,
                Nombres = dto.Nombres,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno
            };
        }

        public static PersonaDto PersonaToDto(PersonaEntity entity)
        {
            return new PersonaDto
            {
                LoginId = entity.LoginId,
                PerfilId = entity.PerfilId,
                PersonaId = entity.PersonaId,
                Rut = entity.Rut,
                Nombres = entity.Nombres,
                ApellidoPaterno = entity.ApellidoPaterno,
                ApellidoMaterno = entity.ApellidoMaterno
            };
        }
    }
}
