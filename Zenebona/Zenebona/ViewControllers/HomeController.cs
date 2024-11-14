using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zenebona.Models;
using Zenebona.Services;

namespace Zenebona.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Zeneszamok() 
        { 
            return View(ZeneszamService.GetZeneszamok());
        }

        public IActionResult Eloadok()
        {
            return View(EloadoService.GetEloadok());
        }

        public IActionResult Kiadok()
        {
            return View(KiadoService.GetKiadok());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
