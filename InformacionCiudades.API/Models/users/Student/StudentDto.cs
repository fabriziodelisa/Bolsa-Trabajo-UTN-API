namespace ApiBolsaTrabajoUTN.API.Models.users.Student
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public int Legajo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
