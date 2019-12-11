using System;

namespace MoiraSoftNegocio.DataTransferObject
{
    public class TurnoDto
    {
        public int RegistroTurnoId { get; set; }
        public int PersonaRegistroId { get; set; }
        public int TurnoId { get; set; }
        public int TipoRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicioRegistro { get; set; }
        public DateTime FechaFinRegistro { get; set; }
    }
}
