using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookKart.Core.Domain.Entities;

namespace BookKart.Core.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
              .HasIndex(b => new { b.EmailId }, "UC_EmailId")
              .IsUnique();
            builder
                .HasIndex(b => new { b.Contact }, "UC_Contact")
                .IsUnique();
        }
    }
}
