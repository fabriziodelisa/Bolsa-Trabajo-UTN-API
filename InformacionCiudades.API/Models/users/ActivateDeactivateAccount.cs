namespace ApiBolsaTrabajoUTN.API.Models.users
{
    public class ActivateDeactivateAccountRequest
    {
        public string? UserId { get; set; }
        public bool Activate { get; set; }
        public bool IsStudent { get; set; }
    }
}
