using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookKart.Core.Domain.Entities;

namespace BookKart.Core.Infrastructure.EntityConfiguration
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder
              .HasIndex(b => new { b.ShippingId }, "UC_ShippingId")
              .IsUnique();
        }
    }
}
