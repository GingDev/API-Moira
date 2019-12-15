namespace MoiraSoftDatos.Entities
{
    public class InfoPersonaLoginEntity
    {
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Prefijo { get; set; }
        public int Telefono { get; set; }
        public bool EsCelular { get; set; }
        public string Direccion { get; set; }
    }
}
