using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    private readonly ShopContext _context;

    public CategoryRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        var result = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        return result;
    }
}
