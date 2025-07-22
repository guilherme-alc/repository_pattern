using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Models;

namespace RepositoryPattern.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
              .IsRequired()
              .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500);
        }
    }
}
