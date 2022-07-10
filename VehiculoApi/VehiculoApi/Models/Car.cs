using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiculoApi.Models
{
    public class Car
    {
        
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public CarModel Model { get; set; }
       
        
     

    }
}
