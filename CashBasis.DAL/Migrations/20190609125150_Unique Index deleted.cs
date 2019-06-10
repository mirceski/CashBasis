using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashBasis.DAL.Migrations
{
    public partial class UniqueIndexdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_CategoryID",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_RecurrenceID",
                table: "Bills");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndtDate",
                table: "Incomes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CategoryID",
                table: "Bills",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RecurrenceID",
                table: "Bills",
                column: "RecurrenceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_CategoryID",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_RecurrenceID",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "EndtDate",
                table: "Incomes");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CategoryID",
                table: "Bills",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RecurrenceID",
                table: "Bills",
                column: "RecurrenceID",
                unique: true,
                filter: "[RecurrenceID] IS NOT NULL");
        }
    }
}
