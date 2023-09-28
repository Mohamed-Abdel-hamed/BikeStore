using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        [MaxLength(255)]
        public string Category_name { get; set;}
    }
}
