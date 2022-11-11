using ApiBolsaTrabajoUTN.API.Enums;

namespace ApiBolsaTrabajoUTN.API.Models.JobPosition
{
    public class CreateJobPositionRequest
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
        public int CareerId { get; set; }
        public int PositionsToCover { get; set; }
        public bool FrameworkAgreement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public JobType JobType { get; set; }
        public WorkDay WorkDay { get; set; }
    }

    public class CreateJobPositionResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
