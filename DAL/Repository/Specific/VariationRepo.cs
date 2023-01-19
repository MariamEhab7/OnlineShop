namespace DAL;

public class VariationRepo : GenericRepo<Variation>, IVariationRepo
{
    private readonly ShopContext _context;

    public VariationRepo(ShopContext context) : base(context)
    {
        _context = context;
    }
}
