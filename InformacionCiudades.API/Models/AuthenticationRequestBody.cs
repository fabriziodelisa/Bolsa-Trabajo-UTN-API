using System.ComponentModel;

namespace ApiBolsaTrabajoUTN.API.Models
{
    public class AuthenticationRequestBody
    {
        [DefaultValue("administracion@frro.utn.edu.ar")]
        public string? Email { get; set; }
        [DefaultValue("MyPassword_?")]
        public string? Password { get; set; }
    }
}
