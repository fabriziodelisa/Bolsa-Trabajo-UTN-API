using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.Services
{
    public class AppRepository //: IAppRepository
    {
        private readonly DBContexts.BolsaTrabajoContext _context;

        public AppRepository(DBContexts.BolsaTrabajoContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }
        //public User? GetUser(int idUser)
        //{
        //    return _context.Users.Where(u => u.Id == idUser).FirstOrDefault();
        //}

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        //public void DeleteUser(int idUser)
        //{
        //    if (GetUser(idUser) == null)
        //    {
        //        throw new ArgumentException("Content nof found");
        //    }
        //    else
        //    {
        //        _context.Users.Remove(GetUser(idUser));
        //    }

        //}
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        //public bool UserExists(int idUser)
        //{
        //    return _context.Users.Any(c => c.Id == idUser);
        //}

        //public User? ValidateCredentials(string email, string password)
        //{
        //    return _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        //}

    }
}
