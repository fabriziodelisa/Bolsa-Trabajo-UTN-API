using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiBolsaTrabajoUTN.API.DBContexts
{
    public class BolsaTrabajoContext : IdentityDbContext<User>
    {
        public DbSet<User> BolsaTrabajoUsers { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public BolsaTrabajoContext(DbContextOptions<BolsaTrabajoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ADMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            string COMPANY_ROLE_ID = "551753f0-bsd2–42de-ffbc-58kmgkmk71cd6";
            string STUDENT_ROLE_ID = "599253f0-asd2–43de-cfbc-58kmgkmk71cd0";


            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            }, new IdentityRole
            {
                Name = "Company",
                NormalizedName = "COMPANY",
                Id = COMPANY_ROLE_ID,
                ConcurrencyStamp = COMPANY_ROLE_ID,
            }, new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Id = STUDENT_ROLE_ID,
                ConcurrencyStamp = STUDENT_ROLE_ID,
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
                UserName = "administracion@frro.utn.edu.ar",
                NormalizedUserName = "ADMINISTRACION@FRRO.UTN.EDU.AR",
            };

            //set user password
            PasswordHasher<Admin> ph = new PasswordHasher<Admin>();
            appUser.PasswordHash = ph.HashPassword(appUser, "MyPassword_?");

            //seed user
            modelBuilder.Entity<Admin>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Career>().HasData(
                new Career
                {
                    Id = 1,
                    Name = "Tecnicatura Universitaria En Programacion",
                    Type = Enums.CareerTypes.Tecnicatura,
                    Abbreviation = "TUP",
                    TotalSubjets = 21,
                    JobPositions = new List<JobPosition>(),
                }
            );

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = 1,
                    SkillName = "Python",
                }, new Skill
                {
                    Id = 2,
                    SkillName = "JavaScript",
                }, new Skill
                {
                    Id = 3,
                    SkillName = "C#",
                }, new Skill
                {
                    Id = 4,
                    SkillName = "Java",
                }, new Skill
                {
                    Id = 5,
                    SkillName = "CSS",
                }, new Skill
                {
                    Id = 6,
                    SkillName = "HTML",
                }
            ) ;

            modelBuilder.Entity<Student>()
                .Property(s => s.SkillsId)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList());

            base.OnModelCreating(modelBuilder);
        }
    }
}
