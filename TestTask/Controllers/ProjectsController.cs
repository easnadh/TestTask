using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
