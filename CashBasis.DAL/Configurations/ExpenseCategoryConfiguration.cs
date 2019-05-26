using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.HasKey(e => e.ExpenseCategoryId);

            builder.Property(e => e.ExpenseCategoryId).HasColumnName("ExpenseCategoryID");

            builder.Property(e => e.Category).IsRequired();
        }
    }
}
