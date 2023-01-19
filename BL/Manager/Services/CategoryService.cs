using AutoMapper;
using DAL;

namespace BL;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepo _categoryRepo;

    public CategoryService(IMapper mapper, ICategoryRepo categoryRepo)
    {
        _mapper = mapper;
        _categoryRepo = categoryRepo;
    }
    public async Task<CategoryReadDTO> AddCategory(CategoryAddDTO model)
    {
        var DbCat = _mapper.Map<Category>(model);
        DbCat.CategoryId = Guid.NewGuid();
        _categoryRepo.Add(DbCat);
        _categoryRepo.SaveChanges();

        var result = _mapper.Map<CategoryReadDTO>(DbCat);
        return result;
    }

    public async Task<CategoryReadDTO> UpdateCategory(CategoryAddDTO model, Guid id)
    {
        var Old = _categoryRepo.GetById(id);
        _mapper.Map(model, Old);
        _categoryRepo.Update(Old);
        _categoryRepo.SaveChanges();
        var result = _mapper.Map<CategoryReadDTO>(Old);
        return result;
    }
    
    public void DeleteCategory(Guid id)
    {
        _categoryRepo.DeleteById(id);
        _categoryRepo.SaveChanges();
    }
}
