using Apollo.DataAccess1.Repository.IRepository;
using Apollo.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Apollo.DataAccess1.Data;
using ApolloWeb.Models;

namespace ApolloWeb.Areas.Espada_2.Controllers
{
    [Area("Espada_2")]
    [Authorize(Roles = $"{SD.Role_Jinchuriki},{SD.Role_Espada}")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWrok;
        public CategoryController(IUnitOfWork unitOfWrok)
        {
            _unitOfWrok = unitOfWrok;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWrok.Category.GetAll().ToList();

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
                _unitOfWrok.Category.Add(obj);
                _unitOfWrok.Save();
                TempData["success"] = "New Category was Created!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Category? categoryFromDb = _unitOfWrok.Category.GetFirstOrDefault(u => u.Id == Id);
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
                _unitOfWrok.Category.update(obj);
                _unitOfWrok.Save();
                TempData["success"] = "Category was Updated!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Category? categoryFromDb = _unitOfWrok.Category.GetFirstOrDefault(u => u.Id == Id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category? obj = _unitOfWrok.Category.GetFirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWrok.Category.Delete(obj);
            _unitOfWrok.Save();
            TempData["success"] = "Category was Deleted";
            return RedirectToAction("Index");
        }
    }
}
