using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class EventChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Client_ClientId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_ClientId",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Event",
                newName: "CaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "Event",
                newName: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ClientId",
                table: "Event",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Client_ClientId",
                table: "Event",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
