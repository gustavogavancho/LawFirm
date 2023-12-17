using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class CaseChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Event_CaseId",
                table: "Event",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Case_CaseId",
                table: "Event",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Case_CaseId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_CaseId",
                table: "Event");
        }
    }
}
