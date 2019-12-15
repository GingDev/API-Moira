using System;

namespace MoiraSoftDatos.Entities
{
    public class PersonaInfoEntity
    {
        public int PersonaId { get; set; }
        public int TurnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Turno { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaInicioTurno { get; set; }
        public DateTime FechaFinTurno { get; set; }
    }
}
