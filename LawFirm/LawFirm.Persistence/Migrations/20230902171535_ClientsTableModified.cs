using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class ClientsTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Client",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Client",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Client",
                newName: "Name");
        }
    }
}
