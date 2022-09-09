using ApiBolsaTrabajoUTN.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Models.User
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "Ingrese su email")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese su UserName")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Agregá una contraseña")]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Agregá un nombre")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Agregá un apellido")]
        public string LastName { get; set; }
    }
}