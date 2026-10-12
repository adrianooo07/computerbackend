using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webshop.Models;

namespace webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        public shopDbContext _context = new();

        [HttpPost("addNewOsystem")]
        public object AddNewOsystem([FromBody] AddNewOsystemDTO newOsystem)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = newOsystem.Name,
                Version = newOsystem.Version,
                RegisterTime = DateTime.Now,
                Updatetime = DateTime.Now
            };
            _context.Osystems.Add(osystem);
            _context.SaveChanges();
            return Ok(new { message = "New OS system added successfully." });
        }
    }
}
