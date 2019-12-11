using System;
using System.Collections.Generic;
using System.Text;

namespace MoiraSoftNegocio.DataTransferObject
{
    public class PersonaDto
    {
        public int PersonaId { get; set; }
        public int PerfilId { get; set; }
        public int LoginId { get; set; }
        public int Rut { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}
