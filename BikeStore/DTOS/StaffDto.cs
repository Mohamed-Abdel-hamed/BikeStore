using BikeStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.DTOS
{
    public class StaffDto
    {
        public int Staff_id { get; set; }
      
        public string Staff_name { get; set; }
       
        public string Email { get; set; }
      
        public string? Phone { get; set; }
        public byte Active { get; set; }
       
        public int Store_id { get; set; }
        public string Store_name { get; set; }
      
        public int? Manager_id { get; set; }
       
    }
}
