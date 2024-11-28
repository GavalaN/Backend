using Microsoft.AspNetCore.Mvc;
using Olimpikonok.Models;
using Olimpikonok.Services;
using System.Diagnostics;

namespace Olimpikonok.Controllers
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

        public IActionResult GetSportolok()
        {
            return View(SportoloService.GetSportoloDTOList());
        }

        public IActionResult NagyKepView(int id)
        {
            return View(SportoloService.GetNagyKep(id));
        }

        public IActionResult GetOrszagok()
        {
            return View(OrszagService.GetOrszagokList());
        }

        public IActionResult SportoloEdit()
        {
            Sportolo sportolo = new Sportolo();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
