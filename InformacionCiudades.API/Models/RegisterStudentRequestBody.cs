using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Models
{
    public class RegisterStudentRequestBody
    {
        [Required(ErrorMessage = "Ingrese su legajo")]
        public int Legajo { get; set; }
        [Required(ErrorMessage = "Ingrese su nombre")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ingrese su apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Ingrese su email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Agregá una contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirma tu contraseña")]
        public string ConfirmPassword { get; set; }
    }
}