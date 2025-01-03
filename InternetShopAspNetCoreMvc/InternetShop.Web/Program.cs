using InternetShop.Data.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using InternetShop.Web.Middleware;
using InternetShop.Services.Implementations;
using InternetShop.Services.Interfaces;
using InternetShop.Repositories.Repositories.Interfaces;
using InternetShop.Repositories.Repositories.Implementations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddDbContext<InternetShopDbContext>(options => 
								options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddNotyf(config => 
{ 
	config.DurationInSeconds = 5; 
	config.IsDismissable = true; 
	config.Position = NotyfPosition.TopRight; 
});

var cultureInfo = new CultureInfo("en-US");
cultureInfo.NumberFormat.NumberDecimalDigits = 2;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
//if (!app.Environment.IsDevelopment())
//{
//	//app.UseExceptionHandler("/Products/Error");
//	app.UseDeveloperExceptionPage();
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}
//else
//{
//	app.UseDeveloperExceptionPage();
//}

app.Use(async (context, next) =>
{
	await next();
	if (context.Response.StatusCode == 404)
	{
		context.Request.Path = "/PageNotFound";
        Console.WriteLine($"404 Error: {context.Request.Path}");
        await next();
	}
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Products}/{action=Index}");

app.UseNotyf();

app.Run();
