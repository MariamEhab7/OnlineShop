namespace BL;

public interface IProductService
{
    Task<ProductReadDTO> AddProduct(ProductAddDTO model);
    void DeleteProduct(Guid id);
    Task<ProductReadDTO> UpdateProduct(ProductAddDTO model, Guid id);
}
