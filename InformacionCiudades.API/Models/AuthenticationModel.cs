using System.ComponentModel;

namespace ApiBolsaTrabajoUTN.API.Models
{
    public class AuthenticationModelRequest
    {
        [DefaultValue("administracion@frro.utn.edu.ar")]
        public string? Email { get; set; }
        [DefaultValue("MyPassword_?")]
        public string? Password { get; set; }
    }
    public class AuthenticationModelResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
