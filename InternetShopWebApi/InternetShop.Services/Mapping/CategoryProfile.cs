using AutoMapper;
using InternetShop.Contract.DTO;
using InternetShop.Data.Models;


namespace InternetShop.Services.Mapping
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryDto>();

			CreateMap<CategoryDto, Category>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());

		}

	}
}
