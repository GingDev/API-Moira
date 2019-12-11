namespace MoiraSoftNegocio.DataTransferObject
{
    public class PersonaContactoDto
    {
        public int PersonaContactoId { get; set; }
        public int PersonaId { get; set; }
        public string Correo { get; set; }
        public int NumeroContacto { get; set; }
        public string Prefijo { get; set; }
        public bool EsTelefonoCelular { get; set; }
        public string Direccion { get; set; }
    }
}
