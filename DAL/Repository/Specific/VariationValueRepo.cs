namespace DAL;

public class VariationValueRepo : GenericRepo<VariationValues>, IVariationValueRepo
{
    private readonly ShopContext _context;

    public VariationValueRepo(ShopContext context) : base(context)
    {
        _context = context;
    }


}
