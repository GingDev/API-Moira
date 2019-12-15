using System;

namespace MoiraSoftNegocio.DataTransferObject
{
    public class InfoTurnoDto
    {
        public int PersonaId { get; set; }
        public int TurnoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicioTurno { get; set; }
        public DateTime FechaTerminoTurno { get; set; }
    }
}
