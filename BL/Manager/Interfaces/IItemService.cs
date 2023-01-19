namespace BL;

public interface IItemService
{
    Task<ItemReadDTO> Additem(ItemAddDTO model);
    Task<ItemReadDTO> UpdateItem(ItemUpdateDTO model, Guid id);
    void DeleteItem(Guid id);
}
