namespace ApiBolsaTrabajoUTN.API.Models.JobApply
{
    public class CreateJobApplyRequest
    {
        public int JobPositionId { get; set; }
    }

    public class CreateJobApplyResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
