using System.Numerics;

namespace DAL;

public interface IGenreRepo : IGenericRepo<GenreOfItems>
{
    Task<GenreOfItems> GetGenreById(Guid id);

}
