using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace BL;

public class ItemServices : IItemService
{
    #region Dependancy Injection
    private readonly IItemRepo _itemRepo;
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;
    private readonly IGenreRepo _genreRepo;
    private readonly IVariationValueRepo _valueRepo;
    private readonly IOrderRepo _orderRepo;

    public ItemServices(IItemRepo itemRepo, IProductRepo productRepo, IMapper mapper,
                        IGenreRepo genreRepo, IVariationValueRepo valueRepo, IOrderRepo orderRepo)
    {
        _itemRepo = itemRepo;
        _productRepo = productRepo;
        _mapper = mapper;
        _genreRepo = genreRepo;
        _valueRepo = valueRepo;
        _orderRepo = orderRepo;
    }
    #endregion

    public async Task<bool> Additem(ItemAddDTO model)
    {
        var DbItem = _mapper.Map<Items>(model);
        DbItem.ItemId = Guid.NewGuid();

        var product = DbItem.Product;
        var assignProduct = _productRepo.GetById(product.ProductId);
        DbItem.Product = assignProduct;

        var value = DbItem.VariationValues;
        DbItem.VariationValues = AssignValue(value);

        var order = DbItem.Orders;
        DbItem.Orders = AssignOrder(order);

        _itemRepo.Add(DbItem);
        _itemRepo.SaveChanges();
        return true;
    }

    public void DeleteItem(Guid id)
    {
        _itemRepo.DeleteById(id);
        _itemRepo.SaveChanges();
    }

    public async Task<ItemReadDTO> UpdateItem(ItemUpdateDTO model, Guid id)
    {
        var OldItem = _itemRepo.GetById(id);
        _mapper.Map(model, OldItem);
        _itemRepo.Update(OldItem);
        _itemRepo.SaveChanges();
        var result = _mapper.Map<ItemReadDTO>(OldItem);
        return result;
    }

    public async Task<ICollection<ItemReadDTO>> GetAllItems()
    {
        var items = _itemRepo.GetAll();
        var result = _mapper.Map<ICollection<ItemReadDTO>>(items);
        return result;
    }

    public async Task<ICollection<ItemReadDTO>> GetItemsOfProduct(Guid id)
    {
        var itemsList = await _itemRepo.GetItemsOfProduct(id);
        var result = _mapper.Map<ICollection<ItemReadDTO>>(itemsList);
        return result;
    }
    
    public async Task<ICollection<ItemReadDTO>> GetItemsByPrice(int price)
    {
        var itemsList = await _itemRepo.GetItemsWithPrice(price);
        var result = _mapper.Map<ICollection<ItemReadDTO>>(itemsList);
        return result;
    }

    public async Task<ICollection<ItemReadDTO>> GetItemDetails(Guid id)
    {
        var item = await _itemRepo.GetItemDetails(id);
        var result = _mapper.Map<ICollection<ItemReadDTO>>(item);
        return result;
    }
    public async Task<bool> AssignVariations(Guid Item, List<Guid> Values)
    {
        var item = await _itemRepo.AssignVariationsToItem(Item, Values);
        if (item == null)
            return false;
        return true;
    }


    #region Helping Methods
    public List<VariationValues> AssignValue (ICollection<VariationValues> value)
    {
        List<VariationValues> values = new List<VariationValues>();
        foreach (var v in value)
        {
            var assign = _valueRepo.GetById(v.ValuesId);
            values.Add(assign);
        }
        return values;
    }

    public List<Order> AssignOrder(ICollection<Order> order)
    {
        List<Order> orders = new List<Order>();
        foreach (var ord in order)
        {
            var assign = _orderRepo.GetById(ord.OrderId);
            orders.Add(assign);
        }
        return orders;
    }

    #endregion

}
