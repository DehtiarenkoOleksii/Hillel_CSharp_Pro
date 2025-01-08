using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(o => o.Id);
			builder.Property(o => o.Id).ValueGeneratedOnAdd();

			builder.Property(o => o.Total)
				   .HasColumnType("decimal(18,2)")
				   .IsRequired();

			builder.Property(o => o.OrderDate)
				   .HasColumnType("datetime")
				   .IsRequired();


			builder.HasOne(o => o.Customer)
				   .WithMany(c => c.Orders)
				   .HasForeignKey(o => o.CustomerId)
				   .IsRequired()
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(o => o.OrderItems)
				   .WithOne(oi => oi.Order)
				   .HasForeignKey(oi => oi.OrderId)
				   .IsRequired()
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
