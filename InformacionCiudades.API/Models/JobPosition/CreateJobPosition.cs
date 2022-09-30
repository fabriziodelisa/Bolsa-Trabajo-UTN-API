namespace ApiBolsaTrabajoUTN.API.Models.JobPosition
{
    public class CreateJobPositionRequest
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
    }

    public class CreateJobPositionResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
