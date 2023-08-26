using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Identity.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d91a22c4-5911-4f1e-b8be-4b847e225c38", "582f5f0b-a72c-44fb-bdb1-89c951273f6b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7d9938-bdfa-40a6-93ce-9fdca75cdd31", "b51c47b2-7388-4b96-ac63-e44dc00ef63b", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91a22c4-5911-4f1e-b8be-4b847e225c38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7d9938-bdfa-40a6-93ce-9fdca75cdd31");
        }
    }
}
