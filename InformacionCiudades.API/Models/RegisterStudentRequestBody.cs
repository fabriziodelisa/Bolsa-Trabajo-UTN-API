using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Models
{
    public class RegisterStudentRequestBody
    {
        [Required(ErrorMessage = "Ingrese su legajo")]
        public int Legajo { get; set; }
        [Required(ErrorMessage = "Ingrese su email")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Agregá una contraseña")]
        [MaxLength(50)] 
        public string Password { get; set; }
    }
}