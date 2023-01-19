using AutoMapper;
using DAL;

namespace BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<ItemAddDTO, Items>();
		CreateMap<ItemUpdateDTO, Items>();

		CreateMap<Items, ItemAddDTO>();
		CreateMap<ProductAddDTO, Product>();
		CreateMap<CategoryAddDTO, Category>();
		CreateMap<VariationValAddDTO, VariationValues>();
		CreateMap<VariationAddDTO, Variation>();

		//neglectable//
		CreateMap<ProductReadDTO, Product>();
		CreateMap<ItemReadDTO, Items>();
		CreateMap<ValuesVarReadDTO, VariationValues>();
		CreateMap<OrderReadDTO, Order>();
		///

		CreateMap<Category, CategoryReadDTO>();
		CreateMap<Product, ProductReadDTO>();
		CreateMap<Items, ItemReadDTO>();
		CreateMap<VariationValues, VariationValReadDTO>();
	}
}
