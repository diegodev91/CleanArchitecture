using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Store.Domain.Common;
using CleanArchitecture.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanArchitecture.Store.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Categories { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "AdminUserID";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "AdminUserID";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Description = "VideoGames", Provider = "Amazon", CreatedBy = "AdminUserID", CreatedDate = DateTime.Now, EndOfContract = new DateTime(2022, 12, 31) });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Description = "TV", Provider = "Local", CreatedBy = "AdminUserID", CreatedDate = DateTime.Now, EndOfContract = new DateTime(2023, 12, 31) });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Description = "Computers", Provider = "Local", CreatedBy = "AdminUserID", CreatedDate = DateTime.Now, EndOfContract = new DateTime(2023, 12, 31) });

            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Play Station 5", Stock = 50, Price = 3500.00M, Currency = "S/.", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "X Box", Stock = 50, Price = 2500.00M, Currency = "S/.", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Nintendo Switch", Stock = 200, Price = 2200.00M, Currency = "S/.", CategoryId = 1 });

            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Samsumg TV 65'", Stock = 150, Price = 5600.00M, Currency = "S/.", CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "LG OLED TV 75'", Stock = 50, Price = 15000.00M, Currency = "S/.", CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Panasonic", Stock = 200, Price = 1500.00M, Currency = "S/.", CategoryId = 2 });

            modelBuilder.Entity<Product>().HasData(new Product() { Name = "MacBook Pro 13'", Stock = 10, Price = 10000.00M, Currency = "S/.", CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Alienware 15'", Stock = 40, Price = 5700.00M, Currency = "S/.", CategoryId = 3 });
            modelBuilder.Entity<Product>().HasData(new Product() { Name = "Asus Pro 2tb 15'", Stock = 100, Price = 2200.00M, Currency = "S/.", CategoryId = 3 });

        }
    }
}