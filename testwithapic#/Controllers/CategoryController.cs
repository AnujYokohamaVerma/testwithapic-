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
                TempData["success"] = "New Category was Created!";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0) { return NotFound(); }
            Category categoryFromDb = _db.Categoryies.Find(Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categoryies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category was Updated!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Category categoryFromDb = _db.Categoryies.Find(Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category obj = _db.Categoryies.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categoryies.Remove(obj); ;
            _db.SaveChanges();
            TempData["success"] = "Category was Deleted";
            return RedirectToAction("Index");
        }
    }
}
