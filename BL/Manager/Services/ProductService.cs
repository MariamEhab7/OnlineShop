using AutoMapper;
using DAL;

namespace BL;

public class ProductService : IProductService
{
    #region DI
    private readonly IProductRepo _productRepo;
	private readonly IMapper _mapper;
	private readonly ICategoryRepo _categoryRepo;
	private readonly IGenreRepo _genreRepo;

	public ProductService(IProductRepo productRepo, IMapper mapper, 
		ICategoryRepo categoryRepo, IGenreRepo genreRepo )
	{
		_productRepo = productRepo;
		_mapper = mapper;
		_categoryRepo = categoryRepo;
		_genreRepo = genreRepo;
	}
    #endregion

    public async Task<ProductReadDTO> AddProduct(ProductAddDTO model)
	{
		var DbProduct= _mapper.Map<Product>(model);
        DbProduct.ProductId = Guid.NewGuid();

        var category = DbProduct.Category;
		var assignCategory = await _categoryRepo.GetCategoryById(category.CategoryId);
		DbProduct.Category = assignCategory;

        var genre = DbProduct.Genre;
		var assignGenre = await _genreRepo.GetGenreById(genre.GenreId);
		DbProduct.Genre = assignGenre;

		_productRepo.Add(DbProduct);
		_productRepo.SaveChanges();
		var readProduct = _mapper.Map<ProductReadDTO>(DbProduct);
		return readProduct;
    }

    public async Task<ProductReadDTO> UpdateProduct(ProductAddDTO model, Guid id)
    {
        var Old = _productRepo.GetById(id);
        _mapper.Map(model, Old );
        _productRepo.Update(Old);
        _productRepo.SaveChanges();
        var result = _mapper.Map<ProductReadDTO>(Old);
        return result;
    } 
	
	public void DeleteProduct(Guid id)
    {
        _productRepo.DeleteById(id);
        _productRepo.SaveChanges();
    }
}
