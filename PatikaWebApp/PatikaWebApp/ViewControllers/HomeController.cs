using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Models;
using PatikaWebApp.Services;
using System.Diagnostics;

namespace PatikaWebApp.Controllers
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

        public IActionResult Gyogyszerek()
        {
            return View(GyogyszerService.GetGyogyszerekList());
        }

        public IActionResult Kezel()
        {
            return View(KezelService.KezelList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
