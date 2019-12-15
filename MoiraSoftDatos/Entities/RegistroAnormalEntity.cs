using System;

namespace MoiraSoftDatos.Entities
{
    public class RegistroAnormalEntity
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoRegistro { get; set; }
        public DateTime InicioRegistro { get; set; }
        public DateTime FinRegistro { get; set; }
    }
}
