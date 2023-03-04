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
                                 .Include(v => v.VariationValues)
                                 .Include(p=>p.Product)
                                 .Include(o=>o.Orders)
                                 .ToList();
        return item;
    }

    public async Task<Items> AssignVariationsToItem(Guid Item, List<Guid> Values)
    {
        var values = _context.VariationValues.Where(v=> Values.Contains(v.ValuesId)).ToList();
        var item = _context.Items.Include(i => i.VariationValues).First(i => i.ItemId == Item);
        foreach(var val in values)
        {
            item.VariationValues.Add(val);
        }
        _context.SaveChanges();
        return item;
    }

}
