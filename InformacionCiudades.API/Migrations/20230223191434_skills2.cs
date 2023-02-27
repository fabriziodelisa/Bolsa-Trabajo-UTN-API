using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class skills2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d27b5de-af48-4903-a660-343c56ed8b5a", "AQAAAAEAACcQAAAAEPVf3Ca+R7eFHSExf3mZOI5XEfdHvOAC20hUKIS4h3nejuIpUg4XvYW2xWrs0byG1g==", "e0510352-4ca8-4c31-a481-258f05e46445" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 1, "Python" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 2, "JavaScript" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 3, "C#" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 4, "Java" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 5, "CSS" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName" },
                values: new object[] { 6, "HTML" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5595cbe9-5c15-4108-8faa-fc46df6680d3", "AQAAAAEAACcQAAAAEA0vXXhtPdu8KV09Qf+HEYvlm2inGMCnFhBoMrjmY2vObmMEtjjBMOgKiAYnJ33DZg==", "3632fb34-aa09-45d9-b036-403d6a86c39e" });
        }
    }
}
