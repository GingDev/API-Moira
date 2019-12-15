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

        public static PersonaInfoDto PersonaInfoToEntity(PersonaInfoEntity entity)
        {
            return new PersonaInfoDto
            {
                TurnoId = entity.TurnoId,
                Apellido = entity.Apellido,
                Cargo = entity.Cargo,
                FechaFinTurno = entity.FechaFinTurno,
                FechaInicioTurno = entity.FechaInicioTurno,
                Nombre = entity.Nombre,
                PersonaId = entity.PersonaId,
                Turno = entity.Turno
            };
        }

        public static List<PersonaInfoDto> PersonaInfoToEntity(List<PersonaInfoEntity> collEntities)
        {
            return collEntities.Select(c => PersonaInfoToEntity(c)).ToList();
        }

        public static RegistroAnormalDto RegistroAnormalToDto(RegistroAnormalEntity entity)
        {
            return new RegistroAnormalDto
            {
                Apellido = entity.Apellido,
                FinRegistro = entity.FinRegistro,
                InicioRegistro = entity.InicioRegistro,
                Nombre = entity.Nombre,
                PersonaId = entity.PersonaId,
                TipoRegistro = entity.TipoRegistro
            };
        }
        public static List<RegistroAnormalDto> RegistroAnormalToDto(List<RegistroAnormalEntity> collEntities)
        {
            return collEntities.Select(c => RegistroAnormalToDto(c)).ToList();
        }

        public static TrabajadorDto TrabajadorToEntity(TrabajadorEntity entity)
        {
            return new TrabajadorDto
            {
                PersonaId = entity.PersonaId,
                Nombre = entity.Nombre
            };
        }

        public static List<TrabajadorDto> TrabajadorToEntity(List<TrabajadorEntity> collEntities)
        {
            return collEntities.Select(c => TrabajadorToEntity(c)).ToList();
        }

        public static InfoPersonaLoginDto InfoPersonaLoginToDto(InfoPersonaLoginEntity entity)
        {
            return new InfoPersonaLoginDto
            {
                Apellido = entity.Apellido,
                Correo = entity.Correo,
                Direccion = entity.Direccion,
                EsCelular = entity.EsCelular,
                Nombres = entity.Nombres,
                PersonaId = entity.PersonaId,
                Prefijo = entity.Prefijo,
                Telefono = entity.Telefono
            };
        }
    }
}
