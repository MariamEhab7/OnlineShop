using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DAL;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<PersonalDetails> PersonalDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Items> Items { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Variation> Variations { get; set; }
    public DbSet<VariationValues> VariationValues { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasOne<PersonalDetails>(s => s.PersonalDetails)
        .WithOne(u => u.User)
        .HasForeignKey<PersonalDetails>(p => p.Id);
    }
}
