using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Olimpikonok.Models;
using Olimpikonok.Services;

namespace Olimpikonok.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SportoloController : ControllerBase
    {
        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            if (id == 0) 
            {
                return Ok(SportoloService.GetSportoloDTOList());
            }
            else
            {
                return Ok(SportoloService.GetSportoloDTOByID(id));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    Sportolo sportolo = new Sportolo()
                    {
                        Id = id
                    };
                    if (context.Sportolos.Select(s => s.Id).Contains(id))
                    {
                        context.Sportolos.Remove(sportolo);
                        context.SaveChanges();
                    }
                    else
                    {
                        return BadRequest($"Nincs ilyen azonosítójú sportoló!");
                    }
                    return Ok("Sikeres törlés!");

                }
                catch (Exception ex)
                {
                    return BadRequest($"Nincs ilyen azonosítójú sportoló!" + ex.Message);
                }
            }
        }
    }
}
