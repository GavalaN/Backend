using KonyvtarApi.DTOs;
using KonyvtarApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KonyvtarakController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    List<Konyvtarak> konyvtaraks = context.Konyvtaraks.ToList();
                    return Ok(konyvtaraks);
                }
                catch (Exception ex)
                {
                    List<Konyvtarak> res = 
                    [
                        new Konyvtarak()
                        {
                            Id = -1,
                            KonyvtarNev = ex.Message,
                        }
                    ];
                    return BadRequest(res);
                }
            }
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> KonyvtarakAsync()
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    List<Konyvtarak> konyvtaraks = await context.Konyvtaraks.ToListAsync();
                    return Ok(konyvtaraks);
                }
                catch (Exception ex)
                {
                    List<Konyvtarak> res =
                    [
                        new Konyvtarak
                        {
                            Id = -1,
                            KonyvtarNev = ex.Message,
                        }
                    ];
                    return BadRequest(res);
                }
            }
        }

        [HttpDelete]
        public IActionResult KonyvtarakDelete(int kId)
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    Konyvtarak konyvtarak = new Konyvtarak()
                    {
                        Id = kId,
                    };
                    context.Konyvtaraks.Remove(konyvtarak);
                    context.SaveChanges();
                    return Ok("Sikeres törlés!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Nincs ilyen elem! "+ex.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult KonyvtarakPost(Konyvtarak ujKonyvtar)
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    context.Add(ujKonyvtar);
                    context.SaveChanges();
                    return Ok("Sikeres felvétel");
                }
                catch (Exception ex)
                {
                    return BadRequest("Hiba a felvétel során! "+ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult KonyvtarakPut(Konyvtarak modositKonyvtar)
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    if (!context.Konyvtaraks.Contains(modositKonyvtar))
                    {
                        return BadRequest("Nem található ez az elem!");
                    }
                    else
                    {
                        context.Konyvtaraks.Update(modositKonyvtar);
                        context.SaveChanges();
                        return Ok("Sikeres módosítás!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Hiba történt! "+ex.Message);
                }
            }
        }

        [HttpGet("DTO")]
        public IActionResult GetKonyvtarakDTO()
        {
            using (var context = new KonyvtarakContext())
            {
                try
                {
                    List<KonyvtarakDTO> konyvtarakDTOs = context.Konyvtaraks.Select(k => new KonyvtarakDTO()
                    {
                        Id = k.Id,
                        Irsz = k.Irsz,
                        Cim = k.Cim,
                        KonyvtarNev = k.KonyvtarNev,
                        MegyeNev = k.IrszNavigation.Megye.MegyeNev,
                        TelepulesNev = k.IrszNavigation.TelepNev
                    }).ToList();
                    return Ok(konyvtarakDTOs);
                }
                catch (Exception ex)
                {
                    return BadRequest("Hiba történt! " + ex.Message);
                }
            }
        }
    }
}
