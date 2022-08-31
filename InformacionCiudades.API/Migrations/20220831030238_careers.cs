using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class careers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Careers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Careers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalSubjets",
                table: "Careers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "223bebfc-52c3-4b67-a989-30475b74d8bb", "AQAAAAEAACcQAAAAELnx5i+pzmNOXhxA9lvau92VyU7Ry8U/g0hRfk0yh+2/qNgAH84bLHF6ZpyidPN/yw==", "5c8d0a88-c18a-456d-9b34-238995343c09" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Abbreviation", "Name", "TotalSubjets", "Type" },
                values: new object[] { "TUP", "Tecnicatura Universitaria En Programacion", 21, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "TotalSubjets",
                table: "Careers");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Careers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b7c97c3-3980-4909-8ccf-7814f3afd4ca", "AQAAAAEAACcQAAAAEPyi/21nVnuT5WDf2oShiTsBSJz5PNy85m4Ff7HTcPTwrluYRyXFdObQWfERD8ZkLw==", "55786656-dd14-41c9-b351-9381a1de49ad" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Type" },
                values: new object[] { 4, 0 });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 2, 5, 0 });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 3, 8, 0 });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 4, 7, 0 });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 5, 6, 0 });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 6, 3, 1 });
        }
    }
}
