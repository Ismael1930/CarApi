using Microsoft.EntityFrameworkCore;

namespace VehiculoApi.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; } 
        public DbSet<CarModel> CarsModel { get; set; }
    }
}
