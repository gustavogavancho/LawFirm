using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Identity.Migrations
{
    public partial class Changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "6eb268ad-9694-4020-98da-6f25f66061c4", "8645b7f9-3a13-42ce-b4ef-185e52fc63db", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2bb4f03-1456-44bd-a52c-dfc9e4829ecf", "2fff2df1-bc66-4221-8780-7c3a7a1fbbd1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ffafa531-566d-440a-bae3-43c1617a5a30", 0, "e569c472-ca10-4e47-884b-e536be02d1ec", "ggavancholeon@gmail.com", false, "", "", false, null, "GGAVANCHOLEON@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEBRSHhjPgsj7hgwaN76nzUgg0hkKRyQqR1ow5/fGHv71W6BvFzYtF/e5ELa6e1y8yA==", null, false, "7b458c68-ca36-455e-a480-50f0116944aa", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6eb268ad-9694-4020-98da-6f25f66061c4", "ffafa531-566d-440a-bae3-43c1617a5a30" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bb4f03-1456-44bd-a52c-dfc9e4829ecf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6eb268ad-9694-4020-98da-6f25f66061c4", "ffafa531-566d-440a-bae3-43c1617a5a30" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eb268ad-9694-4020-98da-6f25f66061c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffafa531-566d-440a-bae3-43c1617a5a30");

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
    }
}
