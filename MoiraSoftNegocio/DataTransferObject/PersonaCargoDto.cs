using System;
using System.Collections.Generic;
using System.Text;

namespace MoiraSoftNegocio.DataTransferObject
{
   public class PersonaCargoDto
    {
        public int PersonaTrabajoId { get; set; }
        public int CargoId { get; set; }
        public int DescripcionCargo { get; set; }
    }
}
