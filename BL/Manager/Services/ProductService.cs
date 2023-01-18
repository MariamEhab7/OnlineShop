using AutoMapper;
using DAL;

namespace BL;

public class ProductService
{
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

	public async Task<ProductReadDTO> AddProduct(ProductAddDTO model)
	{
		var DbProduct= _mapper.Map<Product>(model);
        DbProduct.ProductId = new Guid();

		var catrgory = DbProduct.Category;
		var assignCategory = await _categoryRepo.GetCategoryById(catrgory.CategoryId);
		DbProduct.Category = assignCategory;

        var genre = DbProduct.GenreOfItems;
		var assignGenre = await _genreRepo.GetGenreById(genre.GenreId);
		DbProduct.GenreOfItems = genre;

		_productRepo.Add(DbProduct);
		_productRepo.SaveChanges();
		var readProduct = _mapper.Map<ProductReadDTO>(DbProduct);
		return readProduct;
    }


}
