using Microsoft.AspNetCore.Mvc;
using TestTask.Service.Interfaces;

namespace TestTask.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _staffService.GetStaff();
            if (response.StatusCode == Service.Response.StatusCode.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
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
