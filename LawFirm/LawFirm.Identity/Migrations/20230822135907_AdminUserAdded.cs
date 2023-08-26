using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Identity.Migrations
{
    public partial class AdminUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91a22c4-5911-4f1e-b8be-4b847e225c38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7d9938-bdfa-40a6-93ce-9fdca75cdd31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2619d998-5484-412b-9e8a-64706fc3356d", "0ff6abcd-f67e-4a13-ba7b-ae111e8ac17c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc4d9c4c-76e0-4a6f-9a95-2e39e0bf8083", "54337a26-7ff4-4b68-a8f8-0fde7e2b8146", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23f94478-ccca-497c-8681-d3b84ad96cc3", 0, "283e8ef8-37f7-4646-ba34-e9f9336f72fb", "ggavancholeon@gmail.com", false, "", "", false, null, "GGAVANCHOLEON@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEElfJmERARcDLHydrSsdNWfZYsXNxkNi+sAnXn7ejMw/awHcEcZ7yGRp/SlsQaHZGg==", null, false, "0801c14e-3b3c-47db-9f57-1ba013eebfeb", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dc4d9c4c-76e0-4a6f-9a95-2e39e0bf8083", "23f94478-ccca-497c-8681-d3b84ad96cc3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2619d998-5484-412b-9e8a-64706fc3356d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc4d9c4c-76e0-4a6f-9a95-2e39e0bf8083", "23f94478-ccca-497c-8681-d3b84ad96cc3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc4d9c4c-76e0-4a6f-9a95-2e39e0bf8083");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23f94478-ccca-497c-8681-d3b84ad96cc3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d91a22c4-5911-4f1e-b8be-4b847e225c38", "582f5f0b-a72c-44fb-bdb1-89c951273f6b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7d9938-bdfa-40a6-93ce-9fdca75cdd31", "b51c47b2-7388-4b96-ac63-e44dc00ef63b", "User", "USER" });
        }
    }
}
