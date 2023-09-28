using Microsoft.EntityFrameworkCore;

namespace BikeStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
       public DbSet<Staff> Staffs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
      //  public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_item> Order_items { get; set; }
        public DbSet<Customer> Customers { get; set; }
      
            /* protected override void OnModelCreating(ModelBuilder modelBuilder)
              {
                  modelBuilder.Entity<Stock>()
          .HasKey(p => new { p.Store_id, p.Product_id });
                  modelBuilder.Entity<Product>()
                     .HasOne(c => c.Stock)
                     .WithOne(p => p.Product)
                     .HasForeignKey(c => new { c.Store_id, c.Product_id });


                 /* modelBuilder.Entity<Product>()
                      .HasKey(c => c.Product_id);

                  modelBuilder.Entity<Stock>()
                      .HasOne(c => c.Product)
                      .WithOne(p => p.Stock)
                      .HasForeignKey(c => new { c.Store_id, c.Product_id });*/
            /*modelBuilder.Entity<Stock>()
          .HasOne(s => s.Product)
         // .WithOne(p => p.Stock)
          .HasForeignKey<Product>(p => p.Stock_id);
            //modelBuilder.Entity<Stock>()
     .HasKey(e => new { e.Store_id, e.Product_id });

        }*/
        }
    
}
