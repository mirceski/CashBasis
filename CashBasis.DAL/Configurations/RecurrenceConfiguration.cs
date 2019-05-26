using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashBasis.DAL.Configurations
{
    public class RecurrenceConfiguration : IEntityTypeConfiguration<Recurrence>
    {
        public void Configure(EntityTypeBuilder<Recurrence> builder)
        {
            builder.HasKey(e => e.RecurrenceId);

            builder.Property(e => e.RecurrenceId).HasColumnName("RecurrenceID");

            builder.Property(e => e.Type).IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
