using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
  // [PrimaryKey(("Store_id"), ("Product_id"))]
   
   /* public class Stock
    {
        [Key,Column(Order=0)]
        public int Store_id { get; set; }
        [ForeignKey("Store_id")]
        public Store Store { get; set; }
        [Key, Column(Order = 1)]
        public int Product_id { get; set; }
        [ForeignKey("Product_id ")]
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }*/
}
