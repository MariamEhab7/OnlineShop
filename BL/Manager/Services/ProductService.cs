namespace BL;

public class ProductService
{
	private readonly ProductService _productService;

	public ProductService(ProductService productService)
	{
		_productService = productService;
	}


}
