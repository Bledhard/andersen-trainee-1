using Microsoft.AspNetCore.Mvc;

namespace Fourth.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        [HttpGet("[action]/{city}")]
        public IActionResult City(string city)
        {
            return Ok(new { Temp = "12", Summary = "qwe", City = city });
        }
    }
}