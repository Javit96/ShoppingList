using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingList.Models.Auth;

namespace ShoppingList
{
    public partial class ShoppingListContext : IdentityDbContext<User, Role, Guid>
    {
        public ShoppingListContext()
        {
        }

        public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
            : base(options)
        {
        }

       
        
        public DbSet<Models.StockU> StockU { get; set; }
        public DbSet<Models.Products> Products { get; set; }
        public DbSet<Models.Groups> Groups { get; set; }
        public DbSet<Models.RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Models.StockU>().ToTable("StockU");
            modelBuilder.Entity<Models.Groups>().ToTable("Groups");

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

                

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

           /* modelBuilder.Entity<Models.StockU>().HasOne(s => s.User)
                  .WithMany(u => u.StockU).HasForeignKey(s => s.UserID)
                  .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Models.StockU>().HasOne(s => s.Groups)
                 .WithMany(u => u.StockU).HasForeignKey(s => s.GroupsID)
                 .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Entity<Models.StockU>().HasOne(f => f.Products)
                  .WithMany(u => u.StockU).HasForeignKey(f => f.ProductID)
                  .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);


        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
