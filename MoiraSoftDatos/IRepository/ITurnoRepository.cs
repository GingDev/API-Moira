using MoiraSoftDatos.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoiraSoftDatos.IRepository
{
    public interface ITurnoRepository
    {
        Task<List<InfoTurnoEntity>> GetInfoTurno(string connection);
    }
}
