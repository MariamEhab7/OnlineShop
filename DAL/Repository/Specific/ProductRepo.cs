using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ProductRepo : GenericRepo<Product>,  IProductRepo
{
    private readonly ShopContext _context;

    public ProductRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetChildrenProducts()
    {
        var products = await _context.Products.Where(p => p.Genre.Equals("C")).ToListAsync();
        return products;
    }

    public async Task<ICollection<Product>> GetMenProducts()
    {
        var products = await _context.Products.Where(p => p.Genre.Equals("M")).ToListAsync();
        return products;
    }

    public async Task<ICollection<Product>> GetWomenProducts()
    {
        var products = await _context.Products.Where(p => p.Genre.Equals("F")).ToListAsync();
        return products;
    }
}
