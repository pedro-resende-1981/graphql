using Microsoft.EntityFrameworkCore;

namespace GraphQLPoc.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductLine> ProductLines { get; set; }
    }
}