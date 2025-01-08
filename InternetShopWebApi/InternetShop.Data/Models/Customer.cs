using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Data.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(100)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(100)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[MaxLength(14)]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }


		public virtual ICollection<Order> Orders { get; set; }
	}
}
