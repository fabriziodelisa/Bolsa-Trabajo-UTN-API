using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class addCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Curriculum",
                table: "AspNetUsers",
                type: "BLOB",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5055747-1be0-48dd-8039-3d462fa60267", "AQAAAAEAACcQAAAAEKCxUPRhiBeFdP629dCUqO/OZEh3i9dvIW/J29Ew7sEQhKe1I6NyrLJc7KsKg0qtwA==", "83ffab03-3326-46af-913b-f8fc87279a59" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40997ff9-a166-42e3-9995-5edc0e8ba046", "AQAAAAEAACcQAAAAEPoVyLAo3ybqCt32G1ZXGEMwmk/pBn2cjOJ7aFS6ekKdLIYjPVGxCIbQJcH3cy90qw==", "68cfc1b0-f26a-4d13-94be-af349644fd1c" });
        }
    }
}
