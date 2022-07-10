using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace VehiculoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            return await _context.Cars.Include(c => c.Model).ToListAsync();

        }
        
        

        [HttpGet("{Id}")]
        public async Task<ActionResult<Car>> GetCar(int Id)
        {
            var Cars =  await _context.Cars.FindAsync(Id);

            if (Cars == null)
            {
                return NotFound();  
            }

            return Cars;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> SaveCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new {id = car.Id},car);
        }

        [HttpPut]
        public async Task<IActionResult> EditCar( int id , Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();

            }
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var Car = await _context.Cars.FindAsync(id);

            if(Car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(Car);
            await _context.SaveChangesAsync();

            return NoContent();

        }




    }
}
