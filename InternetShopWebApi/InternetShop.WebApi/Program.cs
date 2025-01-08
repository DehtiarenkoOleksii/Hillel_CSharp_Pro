using FluentValidation.AspNetCore;
using InternetShop.Data.Context;
using InternetShop.Data.Models;
using InternetShop.Repositories.Implementations;
using InternetShop.Repositories.Interfaces;
using InternetShop.Services.Implementations;
using InternetShop.Services.Interfaces;
using InternetShop.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using InternetShop.Services.Validation;
using FluentValidation;

namespace InternetShop.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<InternetShopDBContext>(options =>
			{
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IBaseRepository<Customer>, BaseRepository<Customer>>();
			builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
			builder.Services.AddScoped<IBaseRepository<Product>, BaseRepository<Product>>();
			builder.Services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
			builder.Services.AddScoped<IBaseRepository<OrderItem>, BaseRepository<OrderItem>>();

			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICustomerService, CustomerService>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<IOrderItemService, OrderItemService>();

			builder.Services.AddAutoMapper(typeof(Program));
			builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

			builder.Services.AddFluentValidationAutoValidation();
			builder.Services.AddValidatorsFromAssembly(typeof(ProductValidator).Assembly);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
