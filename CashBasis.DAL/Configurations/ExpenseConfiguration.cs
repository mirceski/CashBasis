using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.ExpenseId);

            builder.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Payee)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.CategoryId)
                .HasColumnName("CategoryID")
                .IsRequired();

            builder.Property(e => e.TotalAmount)
                .HasColumnType("decimal")
                .IsRequired();
            
            builder.HasOne(s => s.Category)
                .WithOne(d => d.Expense)
                .HasForeignKey<Expense>(e => e.CategoryId)
                .HasConstraintName("FK_Expense_ExpenseCategory");
        }
    }
}
