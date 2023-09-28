using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Net.Mail;
namespace BikeStore.Models
{//"IX_UniqueEmail"
    [Index(nameof(Email), IsUnique = true)]
    public class Staff
    {
        [Key]
        public int Staff_id { get; set; }
        [MaxLength(100)]
        public string Staff_name { get; set;}
        [MaxLength(255)] 
        public string Email { get; set; }
        [MaxLength(25)]
        public string? Phone { get; set; }
		public byte Active { get; set;}
		[ForeignKey("Store")]
		public int Store_id { get; set;}
		public Store Store { get; set; }
        [ForeignKey("Staff")]
        public int? Manager_id { get; set; }
        public ICollection<Order> Orders { get; set; }       
    }
}
