namespace DAL;

public interface IProductRepo
{
    Task<ICollection<Product>> GetMenProducts();
    Task<ICollection<Product>> GetWomenProducts();
    Task<ICollection<Product>> GetChildrenProducts();
}
