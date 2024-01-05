using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class LocationEventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");
        }
    }
}
