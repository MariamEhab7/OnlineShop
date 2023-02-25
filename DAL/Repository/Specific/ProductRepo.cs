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
        var products = _context.Products.Where(p => p.Genre.GenreName.Equals("kids")).ToList();
        return products;
    }

    public async Task<ICollection<Product>> GetMenProducts()
    {
        var products = _context.Products.Where(p => p.Genre.GenreName.Equals("men")).ToList();
        return products;
    }

    public async Task<ICollection<Product>> GetWomenProducts()
    {
        var products = _context.Products.Where(p => p.Genre.GenreName.Equals("women")).ToList();
        return products;
    }
}
