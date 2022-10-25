using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Models.Register
{
    public class RegisterCompanyRequestBody
    {
        [Required(ErrorMessage = "Ingrese la razon social")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Ingrese su CUIT")]
        public int Cuit { get; set; }
        [Required(ErrorMessage = "Ingrese su email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirma tu contraseña")]
        public string ConfirmPassword { get; set; }

    }
}
