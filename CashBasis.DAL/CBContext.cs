using System;
using System.Collections.Generic;
using System.Text;
using CashBasis.DAL.Configurations;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashBasis.DAL
{
    public class CBContext : DbContext
    {
        public CBContext(DbContextOptions<CBContext> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<BillItem> Billitems { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Recurrence> Recurrences { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CBContext).Assembly);
        }
    }
}
