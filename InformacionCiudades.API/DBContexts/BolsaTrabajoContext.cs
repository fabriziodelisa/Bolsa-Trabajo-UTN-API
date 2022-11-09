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
                    TotalSubjets = 21
                }
            );

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = 1,
                    SkillName = "C#",
                }, new Skill
                {
                    Id = 2,
                    SkillName = ".NET",
                }, new Skill
                {
                    Id = 3,
                    SkillName = "ASP.NET core",
                }, new Skill
                {
                    Id = 4,
                    SkillName = "Python",
                }, new Skill
                {
                    Id = 5,
                    SkillName = "CSS",
                }, new Skill
                {
                    Id = 6,
                    SkillName = "HTML",
                }, new Skill
                {
                    Id = 7,
                    SkillName = "Javascript",
                }, new Skill
                {
                    Id = 8,
                    SkillName = "Node.js",
                }, new Skill
                {
                    Id = 9,
                    SkillName = "React.js",
                }, new Skill
                {
                    Id = 10,
                    SkillName = "Vue.js",
                }, new Skill
                {
                    Id = 11,
                    SkillName = "Angular",
                }, new Skill
                {
                    Id = 12,
                    SkillName = "SQL",
                }, new Skill
                {
                    Id = 13,
                    SkillName = "JQuery",
                }, new Skill
                {
                    Id = 14,
                    SkillName = "Java",
                }, new Skill
                {
                    Id = 15,
                    SkillName = "C/C++",
                }, new Skill
                {
                    Id = 16,
                    SkillName = "Golang",
                }, new Skill
                {
                    Id = 17,
                    SkillName = "Docker",
                }, new Skill
                {
                    Id = 18,
                    SkillName = "Kubernetes",
                }, new Skill
                {
                    Id = 19,
                    SkillName = "Bootstrap",
                }, new Skill
                {
                    Id = 20,
                    SkillName = "Typescript",
                }, new Skill
                {
                    Id = 21,
                    SkillName = "Entity Framework",
                }, new Skill
                {
                    Id = 22,
                    SkillName = "PHP",
                }, new Skill
                {
                    Id = 23,
                    SkillName = "Git",
                }, new Skill
                {
                    Id = 24,
                    SkillName = "Linux",
                }, new Skill
                {
                    Id = 25,
                    SkillName = "NoSQL",
                }, new Skill
                {
                    Id = 26,
                    SkillName = "Django",
                }, new Skill
                {
                    Id = 27,
                    SkillName = "AWS",
                }, new Skill
                {
                    Id = 28,
                    SkillName = "Wordpress",
                }, new Skill
                {
                    Id = 29,
                    SkillName = "Azure",
                }, new Skill
                {
                    Id = 30,
                    SkillName = "Unit Testing",
                }, new Skill
                {
                    Id = 31,
                    SkillName = "SCRUM",
                }, new Skill
                {
                    Id = 32,
                    SkillName = "Ruby",
                }, new Skill
                {
                    Id = 33,
                    SkillName = "MVC model",
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
