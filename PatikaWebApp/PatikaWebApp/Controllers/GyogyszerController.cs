using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Services;

namespace PatikaWebApp.Controllers
{
    [Route("/[controller]/")]
    [ApiController]
    public class GyogyszerController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GyogyszerService.GetGyogyszerekList());
        }
    }
}
