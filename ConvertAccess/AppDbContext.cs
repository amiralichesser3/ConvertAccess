using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadarshoX.Model.Models.Product;

namespace ConvertAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            this.Database.Connection.ConnectionString = @"data source =79.175.169.197; initial catalog = Madarshox; user id = sa; password = 1234QWer; MultipleActiveResultSets = True; App = EntityFramework";
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<SuitableFor> SuitableFors { get; set; }
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FeatureItem>()
                .HasKey(e => new { e.FeatureId, e.ItemId }); 
            modelBuilder.Entity<ImageItem>()
                .HasKey(e => new { e.ImageId, e.ItemId }); 
        }
    }
}
