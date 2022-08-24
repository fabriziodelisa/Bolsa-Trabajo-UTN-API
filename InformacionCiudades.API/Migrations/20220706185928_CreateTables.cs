using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiBolsaTrabajoUTN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "email1@email.com", "password1", "User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 2, "email2@email.com", "password2", "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 3, "email3@email.com", "password3", "User 3" });

            migrationBuilder.InsertData(
                table: "ApiBolsaTrabajoUTN",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Rating", "Title", "UserId" },
                values: new object[] { 1, "Category 1", "Comment 1", 12, 5, "Title 1", 1 });

            migrationBuilder.InsertData(
                table: "ApiBolsaTrabajoUTN",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Rating", "Title", "UserId" },
                values: new object[] { 2, "Category 2", "Comment 2", 12, 6, "Title 2", 2 });

            migrationBuilder.InsertData(
                table: "ApiBolsaTrabajoUTN",
                columns: new[] { "Id", "Category", "Comment", "Duration", "Rating", "Title", "UserId" },
                values: new object[] { 3, "Category 3", "Comment 3", 12, 7, "Title 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                table: "ApiBolsaTrabajoUTN",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiBolsaTrabajoUTN");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
