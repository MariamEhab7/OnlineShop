namespace BL;

public interface ICategoryService
{
    Task<CategoryReadDTO> AddCategory(CategoryAddDTO category);
    Task<CategoryReadDTO> UpdateCategory(CategoryAddDTO category, Guid id);
    void DeleteCategory(Guid id);
}
