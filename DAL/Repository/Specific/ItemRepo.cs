using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ItemRepo : GenericRepo<Items>, IItemRepo
{
    private readonly ShopContext _context;

    public ItemRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Items>> GetItemsForChildren()
    {
        var items = await _context.Items.Where(p => p.GenreOfItems.Equals("C")).ToListAsync();
        return items;
    }

    public async Task<ICollection<Items>> GetItemsForMen()
    {
        var items = await _context.Items.Where(p => p.GenreOfItems.Equals("M")).ToListAsync();
        return items;
    }

    public async Task<ICollection<Items>> GetItemsForWomen()
    {
        var items = await _context.Items.Where(p => p.GenreOfItems.Equals("F")).ToListAsync();
        return items;
    }

    public async Task<ICollection<Items>> GetItemsOfProduct(Guid id)
    {
        var items = await _context.Items.Where(p => p.Product.ProductId == id).ToListAsync();
        return items;
    }
}
