using ApiBolsaTrabajoUTN.API.Data.Careers;
using ApiBolsaTrabajoUTN.API.Data.JobPositions;
using ApiBolsaTrabajoUTN.API.Data.Skills;
using ApiBolsaTrabajoUTN.API.Data.UsersInfo;
using ApiBolsaTrabajoUTN.API.DBContexts;
using ApiBolsaTrabajoUTN.API.Entities;
using ApiBolsaTrabajoUTN.API.Helpers;
using ApiBolsaTrabajoUTN.API.Services.Authentication;
using ApiBolsaTrabajoUTN.API.Services.Careers;
using ApiBolsaTrabajoUTN.API.Services.JobPositions;
using ApiBolsaTrabajoUTN.API.Services.Mails;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("appApiBearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ac� pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "appApiBearerAuth" }
                }, new List<string>() }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<BolsaTrabajoContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:BolsaTrabajoDBConnectionString"]));

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BolsaTrabajoContext>();
builder.Services.AddIdentityCore<Admin>().AddEntityFrameworkStores<BolsaTrabajoContext>();
builder.Services.AddIdentityCore<Company>().AddEntityFrameworkStores<BolsaTrabajoContext>();
builder.Services.AddIdentityCore<Student>().AddEntityFrameworkStores<BolsaTrabajoContext>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }
);

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

builder.Services.AddScoped<ICareerRepository, CareerRepository>();

builder.Services.AddScoped<ICareerService, CareerService>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddTransient<IJobPositionService, JobPositionService>();

builder.Services.AddTransient<IJobPositionRepository, JobPositionRepository>();
builder.Services.AddTransient<IUsersInfoRepository, UsersInfoRepository>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
