using AutoMapper;
using DAL;

namespace BL;

public class ItemServices
{
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

    public async Task<ItemReadDTO> Additem(ItemAddDTO model)
    {
        var DbItem = _mapper.Map<Items>(model);
        DbItem.ItemId = new Guid();

        var product = DbItem.Product;
        var assignProduct = _productRepo.GetById(product.ProductId);
        DbItem.Product = assignProduct;

        var genre = DbItem.GenreOfItems;
        var assignGenre = _genreRepo.GetById(genre.GenreId);
        DbItem.GenreOfItems = genre;

        var value = DbItem.VariationValues;
        List<VariationValues> values = new List<VariationValues>();
        foreach(var v in value)
        {
            var assign = _valueRepo.GetById(v.ValuesId);
            values.Add(assign);
        }
        DbItem.VariationValues = values;


        var order = DbItem.Orders;
        List<Order> orders = new List<Order>();
        foreach (var ord in order)
        {
            var assign = _orderRepo.GetById(ord.OrderId);
            orders.Add(assign);
        }
        DbItem.Orders = orders;

        _itemRepo.Add(DbItem);
        _itemRepo.SaveChanges();
        var readProduct = _mapper.Map<ItemReadDTO>(DbItem);
        return readProduct;
    }

}
