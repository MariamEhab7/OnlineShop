namespace BL;

public interface IItemService
{
    Task<bool> Additem(ItemAddDTO model);
    Task<ItemReadDTO> UpdateItem(ItemUpdateDTO model, Guid id);
    void DeleteItem(Guid id);
    Task<ICollection<ItemReadDTO>> GetItemsOfProduct(Guid id);
    Task<ICollection<ItemReadDTO>> GetItemsByPrice(int price);
    Task<ICollection<ItemReadDTO>> GetItemDetails(Guid id);
    Task<bool> AssignVariations(Guid Item, List<Guid> Values);
}
