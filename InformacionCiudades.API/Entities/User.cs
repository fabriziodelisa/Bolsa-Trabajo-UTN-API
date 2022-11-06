using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class User : IdentityUser
    {
        public bool FirstChargeData { get; set; } = false;
        public bool ActiveAccount { get; set; } = false;
    }
}
