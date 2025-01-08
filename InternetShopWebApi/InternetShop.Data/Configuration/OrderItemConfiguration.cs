using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configuration
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.HasKey(oi => oi.Id);
			builder.Property(oi => oi.Id).ValueGeneratedOnAdd();

			builder.Property(oi => oi.Quantity)
				   .IsRequired();

			builder.Property(oi => oi.UnitPrice)
				   .HasColumnType("decimal(18,2)")
				   .IsRequired();

			builder.HasOne(oi => oi.Order)
				   .WithMany(o => o.OrderItems)
				   .HasForeignKey(oi => oi.OrderId)
				   .IsRequired()
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(oi => oi.Product)
				   .WithMany(p => p.OrderItems)
				   .HasForeignKey(oi => oi.ProductId)
				   .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
