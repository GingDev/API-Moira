using System.ComponentModel.DataAnnotations;

namespace MoiraSoftNegocio.DataTransferObject
{
    public class Login
    {
        [Required(ErrorMessage = "El canal de ingreso es requerido")]
        public string Usuario { get; set; }
        [StringLength(16, MinimumLength = 8, ErrorMessage = "La Password debe tener al menos 8 caracteres")]
        public string Password { get; set; }
    }
}
