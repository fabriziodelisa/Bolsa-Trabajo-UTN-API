namespace ApiBolsaTrabajoUTN.API.Services.Mails
{
    public interface IMailService
    {

        public bool enviaMail(string To, string TextMessage, string TextSubject);

    }
}
