using Microsoft.EntityFrameworkCore;

namespace DAL;

public class GenreRepo : GenericRepo<Genre>, IGenreRepo
{
    private readonly ShopContext _context;

    public GenreRepo(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Genre?> GetGenreById(Guid id)
    {
        var result = await _context.Genres.AsNoTracking().FirstOrDefaultAsync(c => c.GenreId == id);
        return result;
    }
}

