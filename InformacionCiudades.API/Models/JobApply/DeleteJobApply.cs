namespace ApiBolsaTrabajoUTN.API.Models.JobApply
{
    public class DeleteJobApplyRequest
    {
        public int JobPositionId { get; set; }
    }

    public class DeleteJobApplyResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
}
