using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class CaseChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CounterPart_CaseId",
                table: "CounterPart",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CounterPart_Case_CaseId",
                table: "CounterPart",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CounterPart_Case_CaseId",
                table: "CounterPart");

            migrationBuilder.DropIndex(
                name: "IX_CounterPart_CaseId",
                table: "CounterPart");
        }
    }
}
