using Microsoft.AspNetCore.Mvc;

namespace PlanAPI.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}