using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaAPI.Models;

namespace PatikaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KezelController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Kezel> kezelesek = context.Kezels.ToList();
                    return Ok(kezelesek);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("UjKezel")]
        public IActionResult Post(Kezel UjKezel)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    context.Kezels.Add(UjKezel);
                    context.SaveChanges();
                    return Ok(context);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
