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
            _db.MyProperty.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
