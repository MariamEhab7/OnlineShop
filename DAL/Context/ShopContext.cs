using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DAL;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<PersonalDetails> PersonalDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GenreOfItems> GenreOfItems { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Variation> Variations { get; set; }
    public DbSet<VariationValues> VariationValues { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasOne(b => b.PersonalDetails)
            .WithOne(i => i.Customer)
            .HasForeignKey<PersonalDetails>(b => b.Id);
    }
}
