using Microsoft.AspNetCore.Mvc;
using testwithapic_.Data;

namespace testwithapic_.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }
        
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categoryies.ToList();
            List<MyPropertyController> objMyPropertyList = _db.MyProperty.ToList();
            return View();
        }
    }
}
