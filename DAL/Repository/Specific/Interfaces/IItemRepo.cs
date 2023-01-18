namespace DAL;

public interface IItemRepo : IGenericRepo<Items>
{
    Task<ICollection<Items>> GetItemsForMen();
    Task<ICollection<Items>> GetItemsForWomen();
    Task<ICollection<Items>> GetItemsForChildren();
    Task<ICollection<Items>> GetItemsOfProduct(Guid id);
}
