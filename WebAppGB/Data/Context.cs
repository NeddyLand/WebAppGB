using Microsoft.EntityFrameworkCore;
using WebAppGB.Models;

namespace WebAppGB.Data
{
    public class Context : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial catalog = Store; Trusted_Connection = True; TrustServerCertificate = True").UseLazyLoadingProxies().LogTo(Console.WriteLine);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(pg => pg.ID)
                      .HasName("product_group_pk");

                entity.ToTable("ProductGroups");

                entity.Property(pg => pg.ID)
                      .HasColumnName("pg_name")
                      .HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ID)
                      .HasName("product_pk");

                entity.ToTable("Products");

                entity.Property(p => p.ID)
                      .HasColumnName("prd_name")
                      .HasMaxLength(255);

                entity.HasOne(p => p.ProductGroup).WithMany(pg => pg.Products).HasForeignKey(p => p.ProductGroupID);
            });
            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(p => p.ID)
                      .HasName("storage_pk");

                entity.ToTable("Storages");

                entity.HasMany(s => s.Products).WithMany(p => p.Storages);
            });
        }
    }
}
