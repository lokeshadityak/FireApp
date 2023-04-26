using FireApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireApp.Controllers 
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private static List<Driver> drivers = new List<Driver>();
        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
        public IActionResult GetDrivers()
        {
            var items = drivers.Where(x => x.status == 1).ToList();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult CreateDriver(Driver driver)
        {
            if(ModelState.IsValid)
            {
                drivers.Add(driver);
                return CreatedAtAction("GetDriver", new { driver.Id }, driver);
            }
            return new JsonResult("Something Wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public IActionResult GetDriver(Guid id)
        {
            var driver = drivers.FirstOrDefault(x => x.Id == id);
            if(driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDriver(Guid id, Driver driver) {
            if (id != driver.Id) return BadRequest();

            var existItem = drivers.FirstOrDefault(x => x.Id == id);

            if (existItem == null) return NotFound();

            existItem.Name = driver.Name;
            existItem.contact = driver.contact;
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {
            var driver = drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            driver.status = 0;

            return Ok(driver);
        }*/
    }
}
