using BikeStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.DTOS
{
    public class StoreDto
    {
        public int Store_id { get; set; }
        [MaxLength(255)]
        public string Store_name { get; set; }
        [MaxLength(25)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(255)]
        public string? Street { get; set; }
        [MaxLength(255)]
        public string? City { get; set; }
        [MaxLength(10)]
        public string? State { get; set; }
        [MaxLength(5)]
        public string? Zip_code { get; set; }
        public List<string> Staff_names { get; set; }
       
    }
}
