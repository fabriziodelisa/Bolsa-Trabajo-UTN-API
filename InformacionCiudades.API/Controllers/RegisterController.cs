using AutoMapper;
using ApiBolsaTrabajoUTN.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ApiBolsaTrabajoUTN.API.Models.Register;
using ApiBolsaTrabajoUTN.API.Models.users.Company;
using ApiBolsaTrabajoUTN.API.Models.users.Student;
using ApiBolsaTrabajoUTN.API.mails;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
namespace ApiBolsaTrabajoUTN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<User> userManager,  IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost("RegisterStudent")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(RegisterStudentRequestBody student)
        {
            // Assign email to username
            var newStudent = _mapper.Map<Student>(student);
            newStudent.UserName = student.Email;

            // Verify if role exists, if not create it
            var existsStudentRole = await _roleManager.RoleExistsAsync("Student");
            if (!existsStudentRole)
            {
                await _roleManager.CreateAsync(new IdentityRole("Student"));
            }

            // Create user with Identity
            var result = await _userManager.CreateAsync(newStudent, student.Password);

            // Assign the role
            var res = _userManager.AddToRoleAsync(newStudent, "Student");

            // Validation
            if (result.Succeeded && res.IsCompleted)
            {
                var studentToReturn = _mapper.Map<StudentDto>(newStudent);
                studentToReturn.Password = "";
                string URI = $"https://localhost:7172/api/Register{studentToReturn.Id}";

                string mensaje = "<p>Bienvenido a la bolsa de trabajo de la UTN</p><p>No olvide completar el registro</p><table cellpadding=0 cellspacing=0 class=sc - gPEVay eQYmiW style=vertical - align: -webkit - baseline - middle; font - size: large; font - family: Arial; width: 420px; ><tbody><tr><td><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style = vertical - align: -webkit - baseline - middle; font - size: large; font - family: Arial; width: 100 %;><tbody><tr><td style = text - align: right ><span class=sc-cJSrbW dLwzxs style=display: inline-block; text-align: right; width: 100%><a href = https://accesapp.org/wp-content/uploads/2021/07/logo-utn.png><img src=https://accesapp.org/wp-content/uploads/2021/07/logo-utn.png role=presentation width=100 class=sc-cHGsZl bHiaRe style=max-width: 100px;display: inline;text-align: right;></a></span></td><td width=30><div style=width: 30px></div></td><td><h3 color=#719FED class=sc-fBuWsC eeihxG style=margin: 0px; font-size: 20px; color:#719FED><span></span></h3><p color=000000 font-size=large class=sc-fMiknA bxZCMx style=margin: 0px;color: rgb(0, 0, 0);font-size: 16px;line-height: 24px;><span><em></em></span></p><p color=#000000 font-size=large class=sc-dVhcbM fghLuF style=margin: 0px;font-weight: 500;color: rgb(0, 0, 0);font-size: 16px;line-height: 24px;><span></span></p></td></tr></tbody></table></td></tr><tr><td height=15></td></tr><tr><td color=#719FED  direction=horizontal height=1 class=sc-jhAzac hmXDXQ style=width: 100%;border-bottom: 1px solid rgb(233, 122, 39);border-left: none;display: block;></td></tr><tr><td height=15></td></tr><tr><td><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;padding-left:13px><tbody><tr height=25 style=vertical-align: middle><td width=30 style=vertical-align: middle><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;><tbody><tr><td style=vertical-align: bottom><span color=#719FED width=11 class=sc-jlyJG bbyJzT style=display: block;><a href=tel:0341 448-0102><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/005-phone-call.png color=#719FED width=13 class=sc-iRbamj blSEcj style=display: block;></a></span></td></tr></tbody></table></td><td style=padding: 0px; color: rgb(0, 0, 0)><a href=tel:0341 5271070 color=#000000 class=sc-gipzik iyhjGb style=text-decoration: none;color: rgb(0, 0, 0);font-size: 14px;><span>0341 5271070</span></a></td></tr><tr height=25 style=vertical-align: middle><td width=30 style=vertical-align: middle><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;><tbody><tr><td style=vertical-align: bottom><span color=#719FED  width=11 class=sc-jlyJG bbyJzT style=display: block;><a href=mailto:fakeutn@gmail.com><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/006-email.png color=#719FED width=13 class=sc-iRbamj blSEcj style=display: block;></a></span></td></tr></tbody></table></td><td style=padding: 0p><a href=mailto:fakeutn@gmail.com color=#000000 class=sc-gipzik iyhjGb style=text-decoration: none;color: rgb(0, 0, 0);font-size: 14px;><span>fakeutn@gmail.com</span></a></td></tr><tr height=25 style=vertical-align: middle><td width=30 style=vertical-align: middle><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;><tbody><tr><td style=vertical-align: bottom><span color=#719FED width=11 class=sc-jlyJG bbyJzT style=display: block;><a href=https://www.frro.utn.edu.ar/><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/009-red-mundial.png color=#719FED  width=13 class=sc-iRbamj blSEcj style=display: block;></a></span></td></tr></tbody></table></td><td style=padding: 0px><a href=https://www.frro.utn.edu.ar color=#000000 class=sc-gipzik iyhjGb style=text-decoration: none;color: rgb(0, 0, 0);font-size: 14px;><span>https://www.frro.utn.edu.ar</span></a></td></tr><tr height=25 style=vertical-align: middle><td width=30 style=vertical-align: middle><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;><tbody><tr><td style=vertical-align: bottom><span color=#719FED  width=11 class=sc-jlyJG bbyJzT style=display: block;><a href=https://maps.app.goo.gl/dEiYze4GxD9d29Za8><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/008-geo.png color=#719FED  width=13 class=sc-iRbamj blSEcj style=display: block;></a></span></td></tr></tbody></table></td><td style=padding: 0px><span color=#000000 class=sc-csuQGl CQhxV style=font-size: 14px; color: rgb(0, 0, 0)><a color=#000000 class=sc-gipzik iyhjGb style=text-decoration: none;color: rgb(0, 0, 0);font-size: 14px; href=https://maps.app.goo.gl/dEiYze4GxD9d29Za8> <span>Zeballos 1341</span></a></span></td></tr></tbody></table></td></tr><tr><td height=15></td></tr><tr><td color=#E97A27 direction=horizontal height=1 class=sc-jhAzac hmXDXQ style=width: 100%;border-bottom: 1px solid rgb(233, 122, 39);border-left: none;display: block;></td></tr><tr><td height=15></td></tr><tr><td><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;width: 100%;><tbody><tr><td style=vertical-align: top; text-align: center;><table cellpadding=0 cellspacing=0 class=sc-gPEVay eQYmiW style=vertical-align: -webkit-baseline-middle;font-size: large;font-family: Arial;display: inline-block;><tbody><tr style=text-align: right><td><a href= color=#E97A27 class=sc-hzDkRC kpsoyz style=display: inline-block;padding: 0px;><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/001-facebook.png alt=facebook color=#E97A27 height=36 class=sc-bRBYWo ccSRck style=max-width: 135px;display: block;></a></td><td width=15><div></div></td><td><a href= color=#E97A27 class=sc-hzDkRC kpsoyz style=display: inline-block;padding: 0px;><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/002-gorjeo.png alt=twitter color=#E97A27 height=36 class=sc-bRBYWo ccSRck style=max-width: 135px;display: block;></a></td><td width=15><div></div></td><td><a href= color=#E97A27 class=sc-hzDkRC kpsoyz style=display: inline-block;padding: 0px;><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/003-linkedin.png alt=linkedin color=#E97A27 height=36 class=sc-bRBYWo ccSRck style=max-width: 135px;display: block;></a></td><td width=15><div></div></td><td><a href= color=#E97A27 class=sc-hzDkRC kpsoyz style=display: inline-block;padding: 0px;><img src=https://firma-we-iconos.s3.sa-east-1.amazonaws.com/004-instagram.png alt=instagram color=#E97A27 height=36 class=sc-bRBYWo ccSRck style=max-width: 135px;display: block;></a></td><td width=15><div></div></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td height=15></td></tr></tbody></table>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mensaje, Encoding.UTF8, MediaTypeNames.Text.Html);
                    
                    Mail oMail = new Mail("fakeutn@gmail.com", "lucapecorelli1@gmail.com",
                                    mensaje , "Bienvenidx a la Bolsa de Trabajo de la UTN");

                    if (oMail.enviaMail())
                    {
                        Console.Write("se envio el mail");

                    }
                    else
                    {
                        Console.Write("no se envio el mail: " + oMail.error);
                    }

                    return Created(URI, studentToReturn);
                }
                return BadRequest(result);
            }

        [HttpPost("RegisterCompany")]
        public async Task<ActionResult<CompanyDto>> RegisterCompany(RegisterCompanyRequestBody company)
        {
            // Assign email to username
            var newCompany = _mapper.Map<Company>(company);
            newCompany.UserName = company.Email;

            // Verify if role exists, if not create it
            var existsCompanyRole = await _roleManager.RoleExistsAsync("Company");
            if (!existsCompanyRole)
            {
                await _roleManager.CreateAsync(new IdentityRole("Company"));
            }

            // Create user with Identity
            var result = await _userManager.CreateAsync(newCompany, company.Password);

            // Assign the role
            var res = _userManager.AddToRoleAsync(newCompany, "Company");

            // Validation
            if (result.Succeeded && res.IsCompleted)
            {
                var companyToReturn = _mapper.Map<CompanyDto>(newCompany);
                string URI = $"https://localhost:7172/api/Register{companyToReturn.Id}";
                return Created(URI, companyToReturn);
            }
            return BadRequest(result);
        }
    }
}
