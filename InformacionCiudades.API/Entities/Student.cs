using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Student : User
    {
        [Required]
        public int Legajo { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int CareerId { get; set; }
        public Student(int legajo, string firstName, string lastName)
        {
            Legajo = legajo;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
