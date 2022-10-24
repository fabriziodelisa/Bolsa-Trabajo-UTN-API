using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Admin : User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
