using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(e => e.BillId);
            
            builder.Property(e => e.BillId).HasColumnName("BillID");

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.Vendor)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.CategoryId)
                .HasColumnName("CategoryID")
                .IsRequired();
            
            builder.Property(e => e.RecurrenceId).HasColumnName("RecurrenceID");

            builder.Property(e => e.TotalAmount)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasMany(d => d.BillItems)
                .WithOne(c => c.Bill)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK_Bill_BillItems");
            
            builder.HasOne(s => s.Category)
                .WithOne(d => d.Bill)
                .HasForeignKey<Bill>(e => e.CategoryId)
                .HasConstraintName("FK_Bill_ExpenseCategory");

            builder.HasOne(s => s.Recurrence)
                .WithOne(d => d.Bill)
                .HasForeignKey<Bill>(e => e.RecurrenceId)
                .HasConstraintName("FK_Bill_Recurrence");

            builder.HasIndex(x => x.CategoryId).IsUnique(false);
            builder.HasIndex(x => x.RecurrenceId).IsUnique(false);
        }
    }
}
