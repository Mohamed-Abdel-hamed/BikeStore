using System.ComponentModel.DataAnnotations;

namespace BikeStore.DTOS
{
    public class BrandDto
    {
        public int Brand_id { get; set; }
        [StringLength(255)]
        public string Brand_name { get; set; }
    }
}
