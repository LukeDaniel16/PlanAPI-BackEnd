

using Microsoft.AspNetCore.Mvc;
using PlanAPI.Models;

namespace PlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly PlanDbContext _context;
        
        public UsuarioController(PlanDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();

            return Ok("This worked great!");
        }
    }
}