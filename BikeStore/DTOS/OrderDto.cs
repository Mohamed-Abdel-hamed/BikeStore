using BikeStore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.DTOS
{
    public class OrderDto
    {
        public int Order_id { get; set; }
        public int? Customer_id { get; set; }
        public string Customer_name { get; set; }
        public byte Order_status { get; set; }
        public string Order_date { get; set; }
        public string Required_date { get; set; }
        public string? Shipped_date { get; set; }
        public int Store_id { get; set; }
        public string Store_name { get; set; }
        public int Staff_id { get; set; }
        public string Staff_name { get; set; }
    }
}
