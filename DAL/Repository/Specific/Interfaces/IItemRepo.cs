namespace DAL;

public interface IItemRepo : IGenericRepo<Items>
{
    Task<ICollection<Items>> GetItemsWithPrice(int price);
    Task<ICollection<Items>> GetItemsOfProduct(Guid id);
    Task<ICollection<Items>> GetItemDetails(Guid id);
}
