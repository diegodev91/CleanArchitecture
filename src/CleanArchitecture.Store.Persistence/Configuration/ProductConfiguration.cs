using CleanArchitecture.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Store.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(2000);
            builder.Property(e => e.Stock).HasDefaultValue(0).IsRequired();
            builder.Property(e => e.ImageUrl).HasMaxLength(2000);
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Currency).HasMaxLength(10).IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}