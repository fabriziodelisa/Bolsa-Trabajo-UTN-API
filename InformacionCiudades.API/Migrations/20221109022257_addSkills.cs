using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class addSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AverageWithFails",
                table: "AspNetUsers",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Average",
                table: "AspNetUsers",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillName = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd2a1f35-1894-473a-a49f-7403df8f7a17", "AQAAAAEAACcQAAAAEOGmoXv1iJfqmtiQuFoBqNAUNlN1Y4jMm84k7bcD7HQYrAIDCzfqdHR3wokw++2xNg==", "1463109b-ed73-48de-9ab5-185f9f21c236" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 1, "C#", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 2, ".NET", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 3, "ASP.NET core", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 4, "Python", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 5, "CSS", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 6, "HTML", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 7, "Javascript", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 8, "Node.js", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 9, "React.js", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 10, "Vue.js", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 11, "Angular", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 12, "SQL", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 13, "JQuery", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 14, "Java", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 15, "C/C++", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 16, "Golang", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 17, "Docker", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 18, "Kubernetes", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 19, "Bootstrap", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 20, "Typescript", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 21, "Entity Framework", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 22, "PHP", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 23, "Git", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 24, "Linux", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 25, "NoSQL", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 26, "Django", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 27, "AWS", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 28, "Wordpress", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 29, "Azure", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 30, "Unit Testing", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 31, "SCRUM", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 32, "Ruby", null });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "SkillName", "StudentId" },
                values: new object[] { 33, "MVC model", null });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StudentId",
                table: "Skills",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.AlterColumn<int>(
                name: "AverageWithFails",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Average",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d36c3171-e274-4b65-be29-4cc9b2b05351", "AQAAAAEAACcQAAAAEKptHu6cg9ygv6yyz5eja6DwDFZGRJQjaMbBxnKx9szPkpcnNXyfG7v0klLJ5cJRmg==", "0f643e74-2152-4998-ab67-9afad1cb2e3b" });
        }
    }
}
