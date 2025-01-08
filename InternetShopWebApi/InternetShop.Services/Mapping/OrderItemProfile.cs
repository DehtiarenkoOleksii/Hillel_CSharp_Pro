using AutoMapper;
using InternetShop.Data.Models;
using InternetShop.Contract.DTO;


namespace InternetShop.Services.Mapping
{
	public class OrderItemProfile : Profile
	{
		public OrderItemProfile() 
		{
			CreateMap<OrderItem, OrderItemDto>();

			CreateMap<OrderItemDto, OrderItem>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());
		}
	}
}
