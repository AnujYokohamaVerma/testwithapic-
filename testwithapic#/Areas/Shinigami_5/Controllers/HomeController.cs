using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testwithapic_.Models;
using testwithapic_.Services;

namespace testwithapic_.Areas.Shinigami_5.Controllers
{
    [Area("Shinigami_5")]
    public class HomeController : Controller
    {
        //private readonly IScopedGuideService _scoped1;
        //private readonly IScopedGuideService _scoped2;

        //private readonly ISingletonGuidService _Singleton1;
        //private readonly ISingletonGuidService _Singleton2;

        //private readonly ITransientGuidServices _transient1;
        //private readonly ITransientGuidServices _transient2;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View();
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
