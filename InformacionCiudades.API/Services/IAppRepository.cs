using ApiBolsaTrabajoUTN.API.Entities;

namespace ApiBolsaTrabajoUTN.API.Services
{
    public interface IAppRepository
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int idUser);
        public void CreateUser(User user);
        public bool SaveChanges();
        public void DeleteUser(int idUser);
        public bool UserExists(int idUser);
        public User? ValidateCredentials(string email, string password);
    }
}
