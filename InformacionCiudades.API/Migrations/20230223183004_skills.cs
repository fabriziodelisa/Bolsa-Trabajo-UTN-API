using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBolsaTrabajoUTN.API.Migrations
{
    public partial class skills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5595cbe9-5c15-4108-8faa-fc46df6680d3", "AQAAAAEAACcQAAAAEA0vXXhtPdu8KV09Qf+HEYvlm2inGMCnFhBoMrjmY2vObmMEtjjBMOgKiAYnJ33DZg==", "3632fb34-aa09-45d9-b036-403d6a86c39e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b24e605-8ddc-4100-8111-62268847f8e3", "AQAAAAEAACcQAAAAENfkR+OOM+xEzUqpO84aCjBYIgnaKF+kBpB1h+EdOaXEyBG9dP6jPbDscAXBC/hg9Q==", "763905db-75f8-4fda-9316-fd5be58cd2c8" });
        }
    }
}
