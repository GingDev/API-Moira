using MoiraSoftDatos.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoiraSoftDatos.IRepository
{
    public interface ITurnoRepository
    {
        Task<List<InfoTurnoEntity>> GetInfoTurno(string connection);
        Task<TurnoEntity> CrearTurno(TurnoEntity turno, string connection);
        Task<List<InfoTurnoEntity>> GetInfoLicencia(string connection);
        Task<List<InfoTurnoEntity>> GetInfoVacaciones(string connection);
    }
}
