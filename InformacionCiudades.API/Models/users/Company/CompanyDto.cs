namespace ApiBolsaTrabajoUTN.API.Models.users.Company
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public int Cuit { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
