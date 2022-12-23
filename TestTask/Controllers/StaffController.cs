using Microsoft.AspNetCore.Mvc;
using TestTask.DAL.Interfaces;
using TestTask.Service.Models;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        { 
            _staffRepository = staffRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = _staffRepository.Select();

            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

/*        [HttpPost]
        public IActionResult Check(Staff staff)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/staff");
            }

            return View("Index");
        }*/
    }
}
