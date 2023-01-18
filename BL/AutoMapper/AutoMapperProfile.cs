using AutoMapper;
using DAL;

namespace BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<ProductReadDTO, Product>();
	}
}
