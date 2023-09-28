using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
    public class Order
    {
        [Key]
        public int Order_id { get; set; }
        [ForeignKey("Customer")]
        public int? Customer_id { get; set; }
        public Customer Customer { get; set; }
        public byte Order_status { get; set;}
        public string Order_date { get; set; }
        public string Required_date { get; set; }
        public string? Shipped_date { get; set; }
        [ForeignKey("Store")]
        public int Store_id { get; set; }
        public Store Store { get; set; }
        [ForeignKey("Staff")]
        public int Staff_id { get; set; }
        public Staff Staff { get; set; }
        

    }
}
