using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webshop.Models;
using webshop.Models.DTOs;

namespace webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        public shopDbContext _context = new();

        [HttpPost("addOsystem")]
        public object AddNewOsystem([FromBody] AddNewOsystemDto addNewOsystemDto)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = addNewOsystemDto.Name,
                Version = addNewOsystemDto.Version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now,
            };


            if (osystem != null)
            {
                _context.Osystems.Add(osystem);
                _context.SaveChanges();

                return StatusCode(201, new { message = "Sikeres felvétel", result = osystem });
            }

            return StatusCode(400, new { message = "Sikertelen felvétel", result = osystem });
        }
    }
}
