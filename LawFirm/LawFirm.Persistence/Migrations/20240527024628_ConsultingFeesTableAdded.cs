using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    public partial class ConsultingFeesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultingFee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalAmmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CaseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultingFee_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", nullable: false),
                    ConsultingFeeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_ConsultingFee_ConsultingFeeId",
                        column: x => x.ConsultingFeeId,
                        principalTable: "ConsultingFee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultingFee_CaseId",
                table: "ConsultingFee",
                column: "CaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_ConsultingFeeId",
                table: "Deposit",
                column: "ConsultingFeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "ConsultingFee");
        }
    }
}
