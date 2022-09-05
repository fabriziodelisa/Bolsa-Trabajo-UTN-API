using System.ComponentModel.DataAnnotations;

namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class Student : User
    {
        [Required]
        public int Legajo { get; set; }
        public int CareerId { get; set; }
        public Student(int legajo)
        {
            Legajo = legajo;
        }
    }
}
