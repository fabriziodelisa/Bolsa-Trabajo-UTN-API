using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "turn",
                table: "AspNetUsers",
                newName: "Turn");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "JobPosition",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveAccount",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Company_ActiveAccount",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Company_FirstChargeData",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7541a5f-ec1a-4b72-9477-c50a76158c41", "AQAAAAEAACcQAAAAEOLn4OFYJMCYjovFUcGL+xL+cpTDzxBfn6pTOjNApJXuW2X6tVnK1JRkVgnSGJugCw==", "cebfece9-66fd-4494-8cf1-0579b6088645" });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosition_StudentId",
                table: "JobPosition",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosition_AspNetUsers_StudentId",
                table: "JobPosition",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPosition_AspNetUsers_StudentId",
                table: "JobPosition");

            migrationBuilder.DropIndex(
                name: "IX_JobPosition_StudentId",
                table: "JobPosition");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "JobPosition");

            migrationBuilder.DropColumn(
                name: "ActiveAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Company_ActiveAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Company_FirstChargeData",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Turn",
                table: "AspNetUsers",
                newName: "turn");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9037aa33-3e31-4707-ab37-7c20f68d78e3", "AQAAAAEAACcQAAAAEMRBt3YWuirm0zo8SpO66ppSpDPUiG36CllJqUYxNV40A1QK/0JMhALTmbYBzR19sw==", "689ea52a-2af6-40df-84b4-0046521162d9" });
        }
    }
}
