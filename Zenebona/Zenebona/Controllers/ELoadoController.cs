using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zenebona.Services;

namespace Zenebona.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ELoadoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(EloadoService.GetEloadok());
        }
    }
}
