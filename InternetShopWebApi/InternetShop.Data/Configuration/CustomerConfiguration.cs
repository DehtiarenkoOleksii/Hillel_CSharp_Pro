using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configuration
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();

			builder.Property(c => c.FirstName)
				   .HasColumnType("VARCHAR")
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(c => c.LastName)
				   .HasColumnType("VARCHAR")
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(c => c.Email)
				   .HasColumnType("VARCHAR")
				   .IsRequired()
				   .HasMaxLength(100);

			builder.Property(c => c.Phone)
				   .HasColumnType("VARCHAR")
				   .IsRequired()
				   .HasMaxLength(14);


			builder.HasMany(c => c.Orders)
				   .WithOne(o => o.Customer)
				   .HasForeignKey(o => o.CustomerId)
				   .IsRequired()
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
