using System.Numerics;

namespace DAL;

public interface IGenreRepo : IGenericRepo<Genre>
{
    Task<Genre?> GetGenreById(Guid id);

}
