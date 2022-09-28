using ApiBolsaTrabajoUTN.API.Enums;
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
        public string Email { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Dni { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cuil { get; set; }
        public string Address { get; set; }
        public string AddressNum { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int PhoneNumber { get; set; }
        //como adjuntar cv
        public int CareerId { get; set; }
        public int ApprovedSubjets { get; set; }
        public string PlanDeEstudio { get; set; }
        public int CurrentCareerYear { get; set; }
        public Turn turn { get; set; } //
        public int Average { get; set; }
        public int AverageWithFails { get; set; }
     //   public IEnumerable<string> Skils { get; set; } //??


        //public Student(int legajo, string firstName, string lastName)
        //{
        //    Legajo = legajo;
        //    FirstName = firstName;
        //    LastName = lastName;
        //}
    }
}
