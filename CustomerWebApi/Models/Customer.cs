using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CustomerWebApi.Models
{
	[Table("customer", Schema = "dbo")]
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("customer_id")]
		public int CustomerId { get; set; }
		[Column("customer_name")]
		public string CustomerName { get; set; }
		[Column("mobilenumber")]
		public int MobileNumber { get; set; }
		[Column("email")]
		public string Email { get; set; }
	
		
		
	}
}
