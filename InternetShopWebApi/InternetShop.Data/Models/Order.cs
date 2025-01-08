
using System.ComponentModel.DataAnnotations;


namespace InternetShop.Data.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int CustomerId { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal Total { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime OrderDate { get; set; }


		public virtual Customer Customer { get; set; }
		public virtual ICollection<OrderItem> OrderItems { get; set; }


	}
}
