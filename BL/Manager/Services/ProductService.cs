using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BL;

public class ProductService : IProductService
{
    #region Dependancy Injection
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

    public async Task<bool> AddProduct(ProductAddDTO model)
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
		return true;
    }

    public async Task<ProductReadDTO> UpdateProduct(ProductAddDTO model, Guid id)
    {
        var old = _productRepo.GetById(id);
        _mapper.Map(model, old );
        _productRepo.Update(old);
        _productRepo.SaveChanges();
        var result = _mapper.Map<ProductReadDTO>(old);
        return result;
    } 
	
	public void DeleteProduct(Guid id)
    {
        _productRepo.DeleteById(id);
        _productRepo.SaveChanges();
    }

    public async Task<ICollection<ProductReadDTO>> GetChildrenProducts()
    {
        var prod = await _productRepo.GetChildrenProducts();
        var result = _mapper.Map<ICollection<ProductReadDTO>>(prod);
        return result;
    }

    public async Task<ICollection<ProductReadDTO>> GetMenProducts()
    {
        var prod = await _productRepo.GetMenProducts();
        var result = _mapper.Map<ICollection<ProductReadDTO>>(prod);
        return result;
    }

    public async Task<ICollection<ProductReadDTO>> GetWomenProducts()
    {
        var prod = await _productRepo.GetWomenProducts();
        var result = _mapper.Map<ICollection<ProductReadDTO>>(prod);
        return result;
    }
}
