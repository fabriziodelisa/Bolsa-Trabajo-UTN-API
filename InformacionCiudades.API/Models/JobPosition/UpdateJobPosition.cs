namespace ApiBolsaTrabajoUTN.API.Models.JobPosition
{
    public class UpdateJobPositionRequest
    {
        public int JobPositionId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
    }

    public class UpdateJobPositionResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
