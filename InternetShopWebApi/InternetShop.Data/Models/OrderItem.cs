using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Data.Models
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int OrderId { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public decimal UnitPrice { get; set; }

		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
	}
}
