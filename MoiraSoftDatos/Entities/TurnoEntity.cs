using System;

namespace MoiraSoftDatos.Entities
{
    public class TurnoEntity
    {
        public int RegistroTurnoId { get; set; }
        public int PersonaId { get; set; }
        public int PersonaTrabajoId { get; set; }
        public int TurnoId { get; set; }
        public int TipoRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicioTurno { get; set; }
        public DateTime FechaFinTurno { get; set; }
    }
}
