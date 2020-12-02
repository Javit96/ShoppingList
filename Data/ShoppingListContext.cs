using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ShoppingList
{
    public partial class ShoppingListContext : DbContext
    {
        public ShoppingListContext()
        {
        }

        public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.StockU> StockUs { get; set; }
        public DbSet<Models.Products> Products { get; set; }
        public DbSet<Models.RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>(
                entity =>
                {
                    modelBuilder.Entity<Models.User>(entity =>
                    {
                        entity.HasKey(e => e.UserID)
                            .HasName("PK_user_id_2")
                            .IsClustered(false);

                        entity.ToTable("User");

                        entity.Property(e => e.UserID).HasColumnName("user_id");
                    });
                });
                    modelBuilder.Entity<Models.StockU>().ToTable("StockU");
                    modelBuilder.Entity<Models.Products>().ToTable("Products");
                    modelBuilder.Entity<Models.RefreshToken>(entity =>
                    {
                        entity.HasKey(e => e.TokenId);

                        entity.ToTable("RefreshToken");

                        entity.Property(e => e.TokenId).HasColumnName("token_id");

                        entity.Property(e => e.ExpiryDate)
                            .HasColumnName("expiry_date")
                            .HasColumnType("datetime");

                        entity.Property(e => e.Token)
                            .IsRequired()
                            .HasColumnName("token")
                            .HasMaxLength(200)
                            .IsUnicode(false);

                        entity.Property(e => e.UserId).HasColumnName("user_id");

                        entity.HasOne(d => d.User)
                            .WithMany(p => p.RefreshTokens)
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade);

                    });

                    modelBuilder.Entity<Models.StockU>().HasOne<Models.User>(s => s.User)
                          .WithMany(u => u.StockU).HasForeignKey(s => s.UserID)
                          .OnDelete(DeleteBehavior.Cascade);

                    modelBuilder.Entity<Models.StockU>().HasOne<Models.Products>(f => f.Products)
                          .WithMany(u => u.StockU).HasForeignKey(f => f.ProductID)
                          .OnDelete(DeleteBehavior.Cascade);
                }
           
        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
