
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InternetShop.Data.Models
{ 
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(250)]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }

		[Required]
		public int CategoryId { get; set; }


		public virtual Category Category { get; set; }
		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}


