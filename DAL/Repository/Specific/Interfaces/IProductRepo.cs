namespace DAL;

public interface IProductRepo : IGenericRepo<Product>
{
    Task<ICollection<Product>> GetMenProducts();
    Task<ICollection<Product>> GetWomenProducts();
    Task<ICollection<Product>> GetChildrenProducts();
}
