using Microsoft.AspNetCore.Mvc;

namespace testwithapic_.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
