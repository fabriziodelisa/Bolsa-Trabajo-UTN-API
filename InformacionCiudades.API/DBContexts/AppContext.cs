using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.DBContexts
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
