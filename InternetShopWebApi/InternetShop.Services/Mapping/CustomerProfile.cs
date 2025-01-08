using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;


namespace InternetShop.Services.Mapping
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<Customer, CustomerDto>();

			CreateMap<CustomerDto, Customer>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());

		}

	}
}
