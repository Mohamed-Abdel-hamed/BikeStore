using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
    public class Store
    {
        [Key]
        public int Store_id { get; set; }
        [MaxLength(255)]
        public string Store_name { get; set; }
        [MaxLength(25)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(255)]
        public string ? Street { get; set; }
        [MaxLength(255)]
        public string ? City { get; set; }
        [MaxLength(10)]
        public string? State { get; set; }
        [MaxLength(5)]
        public string? Zip_code { get; set; }
        public ICollection<Staff>Staffs { get; set; }
        public ICollection<Order>Orders { get; set; }
    }
}

