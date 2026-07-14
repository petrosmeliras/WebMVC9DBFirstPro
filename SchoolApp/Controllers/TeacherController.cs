using Microsoft.AspNetCore.Mvc;
using SchoolApp.Core;
using SchoolApp.DTO;
using SchoolApp.Services;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IApplicationService _applicationService;
        public List<Error> ErrorArray { get; set; } = [];

        public TeacherController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(TeacherSignupDTO teacherSignupDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(teacherSignupDTO);
            }

            try
            {
                await _applicationService.TeacherService.SignUpUserAsync(teacherSignupDTO);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ErrorArray.Add(new Error("", ex.Message, ""));
                ViewData["ErrorArray"] = ErrorArray;
                return View(teacherSignupDTO);
            }

        }
    }
}
