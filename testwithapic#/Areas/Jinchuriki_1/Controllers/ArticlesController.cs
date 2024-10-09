using c_.DataAccess1.Repository;
using c_.DataAccess1.Repository.IRepository;
using c_.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using testwithapic_.Data;
using testwithapic_.Models;

namespace testwithapic_.Areas.Jinchuriki_1.Controllers
{
    [Area("Jinchuriki_1")]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ArticlesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Articles> objCategoryList = _unitOfWork.Articles.GetAll().ToList();

            return View(objCategoryList);
        }
        public IActionResult Create3()
        {
            //ArticlesVM articlesVM = new ArticlesVM()
            //{
            //    Articles = new Articles()
            //};
            //articlesVM
            return View();
        }
        [HttpPost]
        public IActionResult Create3(Articles obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Articles");
                   
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageFile= @"\images\Articles\"+fileName;
                }
                else
                {
                    obj.ImageFile = @"\images\Default\default.jfif";
                }
                _unitOfWork.Articles.Add(obj);
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
        public IActionResult Edit(Articles obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string oldImagePath = obj.ImageFile != null ? Path.Combine(wwwRootPath, obj.ImageFile.TrimStart('\\')) : null;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Articles");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageFile = @"\images\Articles\" + fileName;
                }

                if (oldImagePath != null && System.IO.File.Exists(oldImagePath) && !oldImagePath.Contains(@"default"))
                {
                    System.IO.File.Delete(oldImagePath);
                }

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
