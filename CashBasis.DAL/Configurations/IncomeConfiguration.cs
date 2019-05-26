using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(e => e.IncomeId);

            builder.Property(e => e.IncomeId).HasColumnName("IncomeID");

            builder.Property(e => e.RecurrenceId).HasColumnName("RecurrenceID");

            builder.Property(e => e.Company)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.NetAmount)
                .HasColumnType("decimal")
                .IsRequired();

            builder.HasOne(d => d.Recurrence)
                .WithOne(p => p.Income)
                .HasForeignKey<Income>(d => d.RecurrenceId)
                .HasConstraintName("FK_Income_Recurrence");

        }
    }
}
