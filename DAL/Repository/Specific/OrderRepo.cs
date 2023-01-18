using DAL.Repository.Specific;
using DAL.Repository.Specific.Interfaces;

namespace DAL;

public class OrderRepo : GenericRepo<Order> , IOrderRepo
{
    private readonly ShopContext _context;

    public OrderRepo(ShopContext context) : base(context)
    {
        _context = context;
    }
}
