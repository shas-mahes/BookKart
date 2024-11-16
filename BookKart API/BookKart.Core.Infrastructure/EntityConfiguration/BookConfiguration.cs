using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookKart.Core.Domain.Entities;

namespace BookKart.Core.Infrastructure.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
              .HasIndex(b => new { b.Title, b.Author }, "UC_Title_Author")
              .IsUnique();
        }
    }
}
