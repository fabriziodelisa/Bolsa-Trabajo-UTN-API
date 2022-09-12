namespace ApiBolsaTrabajoUTN.API.Entities
{
    public class JobPosition
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
