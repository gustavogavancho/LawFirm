using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCase_CourtCase_CaseId",
                table: "ClientCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtCase",
                table: "CourtCase");

            migrationBuilder.RenameTable(
                name: "CourtCase",
                newName: "Case");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Case",
                table: "Case",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCase_Case_CaseId",
                table: "ClientCase",
                column: "CaseId",
                principalTable: "Case",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCase_Case_CaseId",
                table: "ClientCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Case",
                table: "Case");

            migrationBuilder.RenameTable(
                name: "Case",
                newName: "CourtCase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtCase",
                table: "CourtCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCase_CourtCase_CaseId",
                table: "ClientCase",
                column: "CaseId",
                principalTable: "CourtCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
