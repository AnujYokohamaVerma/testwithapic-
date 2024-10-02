using Microsoft.AspNetCore.Mvc;
using testwithapic_.Data;
using testwithapic_.Models;

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
            
            return View();
        }
    }
}
