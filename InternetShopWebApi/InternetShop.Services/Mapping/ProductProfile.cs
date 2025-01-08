using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;


namespace InternetShop.Services.Mapping
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDto>();

			CreateMap<ProductDto, Product>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());
		}
	}
}
