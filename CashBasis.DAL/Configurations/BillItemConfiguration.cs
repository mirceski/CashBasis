using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    public class BillItemConfiguration : IEntityTypeConfiguration<BillItem>
    {
        public void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder.HasKey(e => e.BillItemId);

            builder.Property(e => e.BillItemId).HasColumnName("BillItemID");

            builder.Property(e => e.BillId).HasColumnName("BillID");

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}
