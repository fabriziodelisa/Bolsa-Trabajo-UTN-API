using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class migracion124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompName",
                table: "AspNetUsers",
                newName: "CompanyName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b313c47-497c-4412-aebd-c61fdb520998", "AQAAAAEAACcQAAAAEHJ4kAIJm4QY3G0YnylUj+fA6Ty3JoBVlMcouo72qnzsZfEKlbughHH7TdM1ZmWdFw==", "b1e41045-bcde-44a0-b0a1-bea4abc6d395" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "AspNetUsers",
                newName: "CompName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb4371b2-70aa-47ab-a6a4-6599c7038c84", "AQAAAAEAACcQAAAAEAaecRN1AijFsh9unJJ0KWqeWhX+Z9sKopu/n1Q0cxpqu27o9EYWireTOOxByHeeeQ==", "10244c54-5ec4-4150-a8d6-91177f684393" });
        }
    }
}
