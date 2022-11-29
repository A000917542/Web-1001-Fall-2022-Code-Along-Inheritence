using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_1001_Fall_2022_Code_Along_Inheritence.Data;
using Web_1001_Fall_2022_Code_Along_Inheritence.Models;

namespace Web_1001_Fall_2022_Code_Along_Inheritence.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StoreContext _ctx;

        public HomeController(ILogger<HomeController> logger, StoreContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] string email)
        {
            _ctx.CurrentUser = email;
            var cart = _ctx.ShoppingCarts.SelectMany(sc => sc.Products).ToList();

            return View("IndexList", cart.AsEnumerable());
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