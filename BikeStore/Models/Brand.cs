using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class Brand
    {
        [Key]
        public int Brand_id { get; set; }
        [MaxLength(255)]
        public string Brand_name { get; set; }
        public ICollection<Order_item> Order_items { get; set; }    
    }
}
