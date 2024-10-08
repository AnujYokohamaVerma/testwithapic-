using c_.DataAccess1.Repository;
using c_.DataAccess1.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using testwithapic_.Data;
using testwithapic_.Models;

namespace testwithapic_.Areas.Jinchuriki_1.Controllers
{
    [Area("Jinchuriki_1")]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticlesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Articles> objCategoryList = _unitOfWork.Articles.GetAll().ToList();

            return View(objCategoryList);
        }
        public IActionResult Create3()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create3(Articles obj)
        {

            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                obj.ModifiedDate = DateTime.Now;
                _unitOfWork.Articles.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "New Article was Created!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Articles? articlesFromDb = _unitOfWork.Articles.GetFirstOrDefault(u => u.Id == Id);
            if (articlesFromDb == null)
            {
                return NotFound();
            }
            return View(articlesFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Articles obj)
        {
            if (ModelState.IsValid)
            {
                var originalArticle = _unitOfWork.Articles.GetFirstOrDefault(u => u.Id == obj.Id);
                if (originalArticle != null)
                {
                    // Detach the original entity
                    _unitOfWork.Articles.Detach(originalArticle);

                    // Preserve the original CreatedDate
                    obj.CreatedDate = originalArticle.CreatedDate;
                }
                obj.ModifiedDate = DateTime.Now;
                _unitOfWork.Articles.update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Article was Updated!";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0) { return NotFound(); }
            Articles? articlesFromDb = _unitOfWork.Articles.GetFirstOrDefault(u => u.Id == Id);
            if (articlesFromDb == null)
            {
                return NotFound();
            }
            return View(articlesFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Articles? obj = _unitOfWork.Articles.GetFirstOrDefault(u => u.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Articles.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Article was Deleted";
            return RedirectToAction("Index");
        }

    }

}
