using Microsoft.EntityFrameworkCore;

namespace DAL;

public class GenreRepo : GenericRepo<GenreOfItems>, IGenreRepo
{
    private readonly ShopContext _context;

    public GenreRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<GenreOfItems> GetGenreById(Guid id)
    {
        var result = await _context.GenreOfItems.AsNoTracking().FirstOrDefaultAsync(c => c.GenreId == id);
        return result;
    }
}

