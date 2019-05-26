﻿// <auto-generated />
using System;
using CashBasis.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashBasis.DAL.Migrations
{
    [DbContext(typeof(CBContext))]
    [Migration("20190523220752_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashBasis.Entities.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BillID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("DueDate");

                    b.Property<int?>("RecurrenceId")
                        .HasColumnName("RecurrenceID");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("BillId");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.HasIndex("RecurrenceId")
                        .IsUnique()
                        .HasFilter("[RecurrenceID] IS NOT NULL");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CashBasis.Entities.BillItem", b =>
                {
                    b.Property<int>("BillItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BillItemID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal");

                    b.Property<int>("BillId")
                        .HasColumnName("BillID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Quantity");

                    b.HasKey("BillItemId");

                    b.HasIndex("BillId");

                    b.ToTable("Billitems");
                });

            modelBuilder.Entity("CashBasis.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ExpenseID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Payee")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal");

                    b.HasKey("ExpenseId");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("CashBasis.Entities.ExpenseCategory", b =>
                {
                    b.Property<int>("ExpenseCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ExpenseCategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.HasKey("ExpenseCategoryId");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("CashBasis.Entities.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IncomeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("decimal");

                    b.Property<int?>("RecurrenceId")
                        .HasColumnName("RecurrenceID");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("IncomeId");

                    b.HasIndex("RecurrenceId")
                        .IsUnique()
                        .HasFilter("[RecurrenceID] IS NOT NULL");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("CashBasis.Entities.Recurrence", b =>
                {
                    b.Property<int>("RecurrenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RecurrenceID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("RecurrenceId");

                    b.ToTable("Recurrences");
                });

            modelBuilder.Entity("CashBasis.Entities.Bill", b =>
                {
                    b.HasOne("CashBasis.Entities.ExpenseCategory", "Category")
                        .WithOne("Bill")
                        .HasForeignKey("CashBasis.Entities.Bill", "CategoryId")
                        .HasConstraintName("FK_Bill_ExpenseCategory")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashBasis.Entities.Recurrence", "Recurrence")
                        .WithOne("Bill")
                        .HasForeignKey("CashBasis.Entities.Bill", "RecurrenceId")
                        .HasConstraintName("FK_Bill_Recurrence");
                });

            modelBuilder.Entity("CashBasis.Entities.BillItem", b =>
                {
                    b.HasOne("CashBasis.Entities.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .HasConstraintName("FK_Bill_BillItems")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashBasis.Entities.Expense", b =>
                {
                    b.HasOne("CashBasis.Entities.ExpenseCategory", "Category")
                        .WithOne("Expense")
                        .HasForeignKey("CashBasis.Entities.Expense", "CategoryId")
                        .HasConstraintName("FK_Expense_ExpenseCategory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashBasis.Entities.Income", b =>
                {
                    b.HasOne("CashBasis.Entities.Recurrence", "Recurrence")
                        .WithOne("Income")
                        .HasForeignKey("CashBasis.Entities.Income", "RecurrenceId")
                        .HasConstraintName("FK_Income_Recurrence");
                });
#pragma warning restore 612, 618
        }
    }
}
