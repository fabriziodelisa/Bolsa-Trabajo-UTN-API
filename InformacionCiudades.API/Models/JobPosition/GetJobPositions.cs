namespace ApiBolsaTrabajoUTN.API.Models.JobPosition
{
    public class GetJobPositionRequest
    {
        public int JobPositionId { get; set; }
    }
    public class GetJobPositionsResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
