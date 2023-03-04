using AutoMapper;
using DAL;

namespace BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<ItemAddDTO, Items>();
		CreateMap<ProductAddDTO, Product>();
        CreateMap<CategoryAddDTO, Category>();
		CreateMap<VariationValAddDTO, VariationValues>();
		CreateMap<VariationAddDTO, Variation>();

		CreateMap<ItemUpdateDTO, Items>();

		CreateMap<Items, ItemAddDTO>();//


		CreateMap<UserInfoDTO, PersonalDetails>();
		CreateMap<UserLoginDTO, User>();
		CreateMap<UserRegisterDTO, User>();

		CreateMap<OrderReadDTO, Order>();

		CreateMap<Category, CategoryReadDTO>();
		CreateMap<Product, ProductReadDTO>();
		CreateMap<Items, ItemReadDTO>();
		CreateMap<VariationValues, VariationValReadDTO>();
		CreateMap<VariationValues, ValuesVarReadDTO>();
	}
}
