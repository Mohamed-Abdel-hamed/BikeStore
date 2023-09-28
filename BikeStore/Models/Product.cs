using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        [MaxLength(255)]
        public string Product_name { get; set; }
        public short Model_year { get; set; }
        public decimal List_price {  get; set;}
        [ForeignKey("Brand")]
        public int Brand_id { get; set; }
        public Brand Brand { get; set; }
        [ForeignKey("Category")]
        public int Category_id { get; set; }
        public Category Category { get; set; }
       // public ICollection<Brand> Brands { get; set; }
       /* [ForeignKey("Stock"),Column(Order =0)]
        public int Store_id { get; set; }
        [ForeignKey("Stock"), Column(Order = 1)]
        public int ProductId { get; set; }
        public Stock Stock { get; set; }*/
    }
    /*CREATE TABLE production.products (
	product_id INT IDENTITY (1, 1) PRIMARY KEY,
	product_name VARCHAR (255) NOT NULL,
	brand_id INT NOT NULL,
	category_id INT NOT NULL,
	model_year SMALLINT NOT NULL,
	list_price DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (category_id) 
        REFERENCES production.categories (category_id) 
        ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (brand_id) 
        REFERENCES production.brands (brand_id) 
        ON DELETE CASCADE ON UPDATE CASCADE
);*/
}
