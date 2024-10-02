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
            
            return View(objCategoryList);
        }
        public IActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create1(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "why you do this man STOP!!");
            }
            if (ModelState.IsValid)
            {
                _db.Categoryies.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Edit(int? id)
        {
            if(id==null ||  id == 0) { return NotFound(); }
            Category categoryFromDb = _db.Categoryies.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "why you do this man STOP!!");
            }
            if (ModelState.IsValid)
            {
                _db.Categoryies.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
