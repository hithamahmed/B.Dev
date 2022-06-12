using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    
    internal class DataContext : DbContext
    {
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SingleProduct> SingleProducts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Ignore<SingleProduct>();
            modelBuilder.Entity<Category>().ToTable("T_Category");
            modelBuilder.Entity<Product>().ToTable("T_Product")
                .Property(x => x.ProductPrice).HasPrecision(18, 3);


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Flowers" },
                new Category { Id = 2, CategoryName = "Gifts" },
                new Category { Id = 3, CategoryName = "confectionery" }
                );

            base.OnModelCreating(modelBuilder);

        }
    }
}
