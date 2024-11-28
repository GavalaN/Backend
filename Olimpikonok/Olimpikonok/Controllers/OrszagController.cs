using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olimpikonok.Services;

namespace Olimpikonok.Controllers
{
    [Route("/[controller]/{id?}")]
    [ApiController]
    public class OrszagController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return Ok(OrszagService.GetOrszagokList());
            }
            else
            {
                return Ok(OrszagService.GetOrszagByID(id));
            }
        }
    }
}
