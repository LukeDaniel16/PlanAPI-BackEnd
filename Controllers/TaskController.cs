using Microsoft.AspNetCore.Mvc;
using PlanAPI.Models;

namespace PlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly PlanDbContext _context;
        
        public TaskController(PlanDbContext context)
        {
            _context = context;
        }
    }
}