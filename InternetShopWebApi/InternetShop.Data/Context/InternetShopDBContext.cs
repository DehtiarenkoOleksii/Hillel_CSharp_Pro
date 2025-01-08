using Microsoft.EntityFrameworkCore;
using InternetShop.Data.Models;
using InternetShop.Data.Configuration;


namespace InternetShop.Data.Context
{
	public class InternetShopDBContext : DbContext
	{
		public InternetShopDBContext(DbContextOptions options) : base(options) { }

		public virtual DbSet<Customer> Customers { get; set; }

		public virtual DbSet<Category> Categories { get; set; }

		public virtual DbSet<Product> Products { get; set; }

		public virtual DbSet<OrderItem> OrderItems { get; set; }

		public virtual DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(InternetShopDBContext).Assembly);

		}

	}
}
