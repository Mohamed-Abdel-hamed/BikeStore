using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class Customer
    {
        [Key]
        public int Customer_id { get; set; }
        [MaxLength(255)]
        public string Customer_name { get; set; }
        [MaxLength(25)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string? Street { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(25)]
        public string? State { get; set; }
        [MaxLength(5)]
        public string? Zip_code { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
