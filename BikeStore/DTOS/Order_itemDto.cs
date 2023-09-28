using BikeStore.Models;

namespace BikeStore.DTOS
{
    public class Order_itemDto
    {
        public int Item_id { get; set; }
        public int Order_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal List_price { get; set; }
        public decimal Descount { get; set; } = decimal.Zero;
        public string Product_name { get; set; }
    }
}
