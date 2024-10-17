using Apollo.DataAccess1.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ApolloWeb.Models;
using ApolloWeb.Services;

namespace ApolloWeb.Areas.Shinigami_5.Controllers
{
    [Area("Shinigami_5")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfwork;


        //private readonly IScopedGuideService _scoped1;
        //private readonly IScopedGuideService _scoped2;

        //private readonly ISingletonGuidService _Singleton1;
        //private readonly ISingletonGuidService _Singleton2;

        //private readonly ITransientGuidServices _transient1;
        //private readonly ITransientGuidServices _transient2;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfwork = unitOfWork;
        }

        //public HomeController(IScopedGuideService scopedGuid1,
        //    IScopedGuideService scopedGuid2,
        //    ISingletonGuidService singletonGuid1,
        //    ISingletonGuidService singletonGuid2,
        //    ITransientGuidServices transientGuid1,
        //    ITransientGuidServices transientGuid2)
        //{
        //    _scoped1 = scopedGuid1;
        //    _scoped2 = scopedGuid2;
        //    _Singleton1 = singletonGuid1;
        //    _Singleton2 = singletonGuid2;
        //    _transient1 = transientGuid1;
        //    _transient2 = transientGuid2;
        //}

        public IActionResult Index()
        {
            IEnumerable<Articles> articlesList = _unitOfwork.Articles.GetAll();
            return View(articlesList);
        }
        public IActionResult Read(int? id)
        {
            Articles article = _unitOfwork.Articles.GetFirstOrDefault(u => u.Id==id);
            return View(article);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
