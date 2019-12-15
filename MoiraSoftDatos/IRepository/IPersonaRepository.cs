using MoiraSoftDatos.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoiraSoftDatos.IRepository
{
    public interface IPersonaRepository
    {
        Task<List<CargoEntity>> GetCargos(string connection);
        Task<PersonaEntity> CrearPersona(PersonaEntity persona, string connection);
        Task<List<PersonaInfoEntity>> GetInfoPersonaTurno(string connection);
        Task<List<RegistroAnormalEntity>> GetInfoRegistroAnormal(string connection);
        Task<List<TrabajadorEntity>> GetTrabajadores(string connection);
    }
}
