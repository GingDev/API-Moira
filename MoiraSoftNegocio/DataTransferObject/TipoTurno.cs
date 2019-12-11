using System;
using System.Collections.Generic;
using System.Text;

namespace MoiraSoftNegocio.DataTransferObject
{
   public class TipoTurno
    {
        public int TipoTurnoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
