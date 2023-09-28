using System.ComponentModel.DataAnnotations;

namespace BikeStore.DTOS
{
    public class CustomerDto
    {
        public int Customer_id { get; set; }
        [StringLength(255)]
        public string Customer_name { get; set; }
        [StringLength(25)]
        public string? Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string? Street { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(25)]
        public string? State { get; set; }
        [StringLength(5)]
        public string? Zip_code { get; set; }
    }
}
