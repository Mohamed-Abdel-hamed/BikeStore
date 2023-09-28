using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
   [PrimaryKey(("Order_id"),("Item_id"))]
    public class Order_item
    {
        public int Item_id { get; set; }
        public int Order_id { get; set; }
        public int Product_id { get; set;}
        public int Quantity { get; set; }
        public decimal List_price { get; set; }
        public decimal Descount { get; set; }=decimal.Zero;
        [ForeignKey("Order_id")]
        public Order Order { get; set; }
        [ForeignKey("Product_id")]
        public Product Product { get; set; }
    }
    }

