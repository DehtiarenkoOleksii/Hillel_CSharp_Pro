using InternetShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();

			builder.Property(c => c.Name)
				   .HasColumnType("VARCHAR")
				   .IsRequired()
				   .HasMaxLength(100);

			builder.HasMany(cat => cat.Products)
				   .WithOne(p => p.Category)
				   .HasForeignKey(p => p.CategoryId)
				   .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
