using c_.DataAccess1.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using testwithapic_.Data;
using testwithapic_.Models;

namespace testwithapic_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository db) {
            _categoryRepository = db;
        }
        
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
            
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
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
                TempData["success"] = "New Category was Created!";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0) { return NotFound(); }
            Category? categoryFromDb = _categoryRepository.GetFirstOrDefault(u => u.Id == Id);
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
                _categoryRepository.update(obj);
                _categoryRepository.Save();
                TempData["success"] = "Category was Updated!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Category? categoryFromDb = _categoryRepository.GetFirstOrDefault(u => u.Id == Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category? obj = _categoryRepository.GetFirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(obj);
            _categoryRepository.Save();
            TempData["success"] = "Category was Deleted";
            return RedirectToAction("Index");
        }
    }
}
