using CleanArchitecture.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Store.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(2000);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(e => e.Provider).HasMaxLength(500).IsRequired();
            builder.Property(e => e.EndOfContract).IsRequired();
        }
    }
}