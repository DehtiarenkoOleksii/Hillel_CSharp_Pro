using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;


namespace InternetShop.Services.Mapping
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
			CreateMap<Order, OrderDto>()
				.ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

			CreateMap<OrderDto, Order>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.OrderItems, opt => opt.Ignore());

		}

	}
}
