
using AutoMapper;
using LinkedSystems.BL.DTOs;
using LinkedSystems.DAL;

namespace LinkedSystems.BL;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Product, ProductReadDTO>();
        CreateMap<ProductAddDTO, Product>();
        CreateMap<ProductUpdateDTO, Product>();

    }
}
