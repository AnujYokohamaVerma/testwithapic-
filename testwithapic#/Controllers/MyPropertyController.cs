using Microsoft.AspNetCore.Mvc;
using testwithapic_.Data;
using testwithapic_.Models;

namespace testwithapic_.Controllers
{
    public class MyPropertyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MyPropertyController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<MyProperty> objmypropertylist = _db.MyProperty.ToList();
            return View(objmypropertylist);
        }
        public IActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create2(MyProperty obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and the Display Order can not be the same!");
            }
            if (ModelState.IsValid)
            {
                _db.MyProperty.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New Property was Created!";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            MyProperty propertyFromDb = _db.MyProperty.Find(Id);
            if (propertyFromDb == null)
            {
                return NotFound();
            }
            return View(propertyFromDb);
        }
        [HttpPost]
        public IActionResult Edit(MyProperty obj)
        {
            if (ModelState.IsValid)
            {
                _db.MyProperty.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Property was Updated!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            MyProperty propertyFromDb = _db.MyProperty.Find(Id);
            if (propertyFromDb == null)
            {
                return NotFound();
            }
            return View(propertyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            MyProperty obj = _db.MyProperty.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.MyProperty.Remove(obj); ;
            _db.SaveChanges();
            TempData["success"] = "Property was Deleted";
            return RedirectToAction("Index");

        }
    }
}
