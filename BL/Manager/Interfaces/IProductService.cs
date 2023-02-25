namespace BL;

public interface IProductService
{
    Task<bool> AddProduct(ProductAddDTO model);
    void DeleteProduct(Guid id);
    Task<ProductReadDTO> UpdateProduct(ProductAddDTO model, Guid id);

    Task<ICollection<ProductReadDTO>> GetChildrenProducts();
    Task<ICollection<ProductReadDTO>> GetMenProducts();
    Task<ICollection<ProductReadDTO>> GetWomenProducts();

}
