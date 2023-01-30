namespace DAL;

public interface ICategoryRepo : IGenericRepo<Category>
{
    Task<Category?> GetCategoryById(Guid id);
}
