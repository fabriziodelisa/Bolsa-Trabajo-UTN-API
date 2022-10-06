using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "907a22ea-6f48-4227-98e7-9fb33bff2243", "AQAAAAEAACcQAAAAEOgcLhT52glnPt7Cv/CTqP26dcvjdODE8RDLCCsb5ySV7MSemnb9LCl42XMlrMtpXQ==", "2eac5a5d-cd0e-4054-8c08-7a3b57954a93" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b313c47-497c-4412-aebd-c61fdb520998", "AQAAAAEAACcQAAAAEHJ4kAIJm4QY3G0YnylUj+fA6Ty3JoBVlMcouo72qnzsZfEKlbughHH7TdM1ZmWdFw==", "b1e41045-bcde-44a0-b0a1-bea4abc6d395" });
        }
    }
}
