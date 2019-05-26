using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashBasis.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    ExpenseCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExpenseCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Recurrences",
                columns: table => new
                {
                    RecurrenceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurrences", x => x.RecurrenceID);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Payee = table.Column<string>(maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseCategory",
                        column: x => x.CategoryID,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExpenseCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    RecurrenceID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Vendor = table.Column<string>(maxLength: 100, nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bill_ExpenseCategory",
                        column: x => x.CategoryID,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExpenseCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Recurrence",
                        column: x => x.RecurrenceID,
                        principalTable: "Recurrences",
                        principalColumn: "RecurrenceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    IncomeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecurrenceID = table.Column<int>(nullable: true),
                    Company = table.Column<string>(maxLength: 100, nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.IncomeID);
                    table.ForeignKey(
                        name: "FK_Income_Recurrence",
                        column: x => x.RecurrenceID,
                        principalTable: "Recurrences",
                        principalColumn: "RecurrenceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Billitems",
                columns: table => new
                {
                    BillItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billitems", x => x.BillItemID);
                    table.ForeignKey(
                        name: "FK_Bill_BillItems",
                        column: x => x.BillID,
                        principalTable: "Bills",
                        principalColumn: "BillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billitems_BillID",
                table: "Billitems",
                column: "BillID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryID",
                table: "Expenses",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_RecurrenceID",
                table: "Incomes",
                column: "RecurrenceID",
                unique: true,
                filter: "[RecurrenceID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billitems");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "Recurrences");
        }
    }
}
