using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class ChangeTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourtCase_Client_ClientId",
                table: "CourtCase");

            migrationBuilder.DropIndex(
                name: "IX_CourtCase_ClientId",
                table: "CourtCase");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "CourtCase");

            migrationBuilder.DropColumn(
                name: "Nit",
                table: "CourtCase");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CourtCase",
                newName: "FileNumber");

            migrationBuilder.CreateTable(
                name: "ClientCase",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CaseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCase", x => new { x.CaseId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientCase_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCase_CourtCase_CaseId",
                        column: x => x.CaseId,
                        principalTable: "CourtCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCase_ClientId",
                table: "ClientCase",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCase");

            migrationBuilder.RenameColumn(
                name: "FileNumber",
                table: "CourtCase",
                newName: "Status");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "CourtCase",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Nit",
                table: "CourtCase",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CourtCase_ClientId",
                table: "CourtCase",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtCase_Client_ClientId",
                table: "CourtCase",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
