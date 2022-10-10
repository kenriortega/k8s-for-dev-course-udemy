using AppNetcoreK8s.Models;

namespace AppNetcoreK8s.Data;

public class ApiContext : DbContext
{
    static ApiContext(){
    }

    public virtual DbSet<Product> Products { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options) : base(options){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Product>(entity => {
            entity.HasData(
                new Product {Id = 1, Name = "Laptop"},
                new Product {Id = 2, Name = "Keyboard"},
                new Product {Id = 3, Name = "Monitor"},
                new Product {Id = 4, Name = "Mobil"},
                new Product {Id = 5, Name = "PC"}
            );
        });
    }
}