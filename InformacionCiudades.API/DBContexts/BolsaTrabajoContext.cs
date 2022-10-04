    using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.DBContexts
{
    public class BolsaTrabajoContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Company> Companies { get; set; } 
        public DbSet<Student> students { get; set; }

        public BolsaTrabajoContext(DbContextOptions<BolsaTrabajoContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new Admin
            {
                Id = ADMIN_ID,
                Email = "administracion@frro.utn.edu.ar",
                NormalizedEmail = "ADMINISTRACION@FRRO.UTN.EDU.AR",
                EmailConfirmed = true,
                FirstName = "Administracion",
                LastName = "Utn",
            };

            //set user password
            PasswordHasher<Admin> ph = new PasswordHasher<Admin>();
            appUser.PasswordHash = ph.HashPassword(appUser, "MyPassword_?");

            //seed user
            modelBuilder.Entity<Admin>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Career>().HasData(
                new Career
                {
                    Id = 1,
                    Name = "Tecnicatura Universitaria En Programacion",
                    Type = Enums.CareerTypes.Tecnicatura,
                    Abbreviation = "TUP",
                    TotalSubjets = 21
                }
            ); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
