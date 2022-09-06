namespace ApiBolsaTrabajoUTN.API.Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public int Legajo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
