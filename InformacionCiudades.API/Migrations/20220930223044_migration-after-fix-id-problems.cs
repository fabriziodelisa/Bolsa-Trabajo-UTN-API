using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class migrationafterfixidproblems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPositions_AspNetUsers_CompanyId1",
                table: "JobPositions");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "JobPositions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5756601-c441-4789-b77a-18eea890c506", "AQAAAAEAACcQAAAAEAiDM4QO7F0TL6A+9dAMvAfpaw+TcNiMqqLZoJpqmBSLHW7b6xCSQ0lqN13REg8cug==", "f8877395-23f3-4368-8c8e-39fb9fe414c2" });

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_StudentId",
                table: "JobPositions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPositions_AspNetUsers_CompanyId",
                table: "JobPositions",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPositions_AspNetUsers_CompanyId",
                table: "JobPositions");

            migrationBuilder.DropIndex(
                name: "IX_JobPositions_StudentId",
                table: "JobPositions");

            migrationBuilder.AddColumn<string>(
                name: "CompanyId1",
                table: "JobPositions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a519e32c-0fd5-4837-a0a4-931b7ec2d1aa", "AQAAAAEAACcQAAAAEFLeHMLp1dyuwQ8qNcR5mi03FbtMBBSxj5rXxz71hIaN66e3YTUgpejy7Plf5QPkaw==", "8fb566b9-a283-4309-b6f6-2f8de843269a" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobPositions_AspNetUsers_CompanyId1",
                table: "JobPositions",
                column: "CompanyId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
