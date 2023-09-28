using BikeStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.DTOS
{
    public class ProductDto
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public short Model_year { get; set; }
        public decimal List_price { get; set; }
        public int Brand_id { get; set; }
        public int Category_id { get; set; }
        public string Brand_name { get; set; }
        public string Category_name { get; set; }
    }
}
