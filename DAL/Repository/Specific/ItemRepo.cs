using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ItemRepo : GenericRepo<Items>, IItemRepo
{
    private readonly ShopContext _context;

    public ItemRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Items>> GetItemsWithPrice(int price)
    {
        var items = _context.Items.Where(p => p.Price < price).ToList();
        return items;
    }

    public async Task<ICollection<Items>> GetItemsOfProduct(Guid id)
    {
        var items = _context.Items.Where(i=>i.Product.ProductId == id).ToList();
        return items;
    }

    public async Task<ICollection<Items>> GetItemDetails(Guid id)
    {
        var item = _context.Items.Where(i => i.ItemId == id)
                                 .Include(v => v.VariationValues).ToList();
        return item;
    }
}
