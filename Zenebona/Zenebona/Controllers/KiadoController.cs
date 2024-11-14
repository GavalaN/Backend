using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zenebona.Services;

namespace Zenebona.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class KiadoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(KiadoService.GetKiadok());
        }
    }
}
