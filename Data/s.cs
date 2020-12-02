using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingList.ConectionController;

namespace ShoppingList.Data
{
    public class s 
    {
        public s(DbContextOptions<ShoppingListContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseMySQL(connectionString: "DefaultConnection");
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.StockU> StockUs { get; set; }
        public DbSet<Models.Products> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>().ToTable("User");
            modelBuilder.Entity<Models.StockU>().ToTable("StockU");
            modelBuilder.Entity<Models.Products>().ToTable("Products");
        }
       
    }
}
