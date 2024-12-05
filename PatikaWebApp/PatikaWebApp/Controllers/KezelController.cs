using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Services;

namespace PatikaWebApp.Controllers
{
    [Route("/[controller]/")]
    [ApiController]
    public class KezelController : Controller
    {
        [HttpGet("{id?}")]
        public IActionResult Get(int Id)
        {
            return Ok(KezelService.KezelById(Id));
        }
    }
}
