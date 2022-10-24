namespace ApiBolsaTrabajoUTN.API.Models.JobApply
{
    public class GetJobAppliesOfStudentRequest
    {
        public int JobPositionId { get; set; }
    }
    public class GetJobAppliesOfStudentResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
