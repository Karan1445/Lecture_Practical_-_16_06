using Microsoft.AspNetCore.Mvc;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
