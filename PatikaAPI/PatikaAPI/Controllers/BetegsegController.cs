﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaAPI.Models;
using System.Security.Cryptography.Xml;
using PatikaAPI.DTOs;

namespace PatikaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BetegsegController : ControllerBase
    {
        #region Szikron végpontok

        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = context.Betegsegs.ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> result =
                    [
                        new Betegseg
                        {
                            Id = -1,
                            Megnevezes = ex.Message
                        },
                    ];
                    return StatusCode(400,result);
                }
            }
        }

        [HttpGet("ById")]
        public IActionResult Get(int id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Betegseg result = context.Betegsegs.FirstOrDefault(b => b.Id == id);
                    if (result == null)
                        return NotFound("Nincs ilyen azonosítójú betegség");
                    else
                        return Ok(result);
                }
                catch (Exception ex)
                {
                    Betegseg hiba = new Betegseg
                    {
                        Id = -1,
                        Megnevezes = ex.Message
                    };
                    return StatusCode(400, hiba);
                }
            }
        }

        [HttpGet("ToGyogyszerNev")]
        public IActionResult Get(string gynev)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Gyogyszer.Nev == gynev).Select(k => k.Betegseg).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> result = new List<Betegseg>();
                    result.Add(new Betegseg
                    {
                        Id = -1,
                        Megnevezes=ex.Message
                    });
                    return StatusCode(400, result);
                }
            }
        }

        [HttpGet("ToGyogyszerId")]
        public IActionResult GetById(int id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Gyogyszer.Id == id).Select(k => k.Betegseg).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> result = new List<Betegseg>();
                    result.Add(new Betegseg
                    {
                        Id = -1,
                        Megnevezes = ex.Message
                    });
                    return StatusCode(400, result);
                }
            }
        }

        [HttpGet("BetegsegDTO")]
        public IActionResult GetBetegsegDTO()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<BetegsegDTO> result = context.Betegsegs.Select(b => new BetegsegDTO()
                    {
                        Id = b.Id,
                        Megnevezes = b.Megnevezes,
                    }).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<BetegsegDTO> result =
                    [
                        new BetegsegDTO
                        {
                            Id = -1,
                            Megnevezes = ex.Message
                        },
                    ];
                    return StatusCode(400, result);
                }
            }
        }

        [HttpPost("Ujbetegseg")]
        public IActionResult Post(Betegseg betegseg)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    context.Betegsegs.Add(betegseg);
                    context.SaveChanges();
                    return Ok("Sikeres rögzítés");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        [HttpDelete("TorlesBetegseg")]
        public IActionResult Delete(int Id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Betegseg torlendo = new Betegseg()
                    {
                        Id = Id,
                    };
                    context.Betegsegs.Remove(torlendo);
                    context.SaveChanges();
                    return Ok("Sikeres törlés!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("ModositBetegseg")]
        public IActionResult Put(Betegseg ujBetegseg)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    if (context.Betegsegs.Contains(ujBetegseg))
                    {
                        context.Betegsegs.Update(ujBetegseg);
                        context.SaveChanges();
                        return Ok("Sikeres módosítás!");
                    }
                    else
                    {
                        return NotFound("Nincs ilyen elem!");
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion

        #region Aszinkron végpontok
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = await context.Betegsegs.ToListAsync();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> hibalista = new List<Betegseg>()
                    {
                        new Betegseg()
                        {
                            Id = -1,
                            Megnevezes = ex.Message,
                        }
                    };
                    return BadRequest(hibalista);
                }
            }
        }

        [HttpGet("ByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Betegseg result = await context.Betegsegs.FirstOrDefault(b => b.Id == id);
                    if (result == null)
                        return NotFound("Nincs ilyen azonosítójú betegség");
                    else
                        return Ok(result);
                }
                catch (Exception ex)
                {
                    Betegseg hiba = new Betegseg
                    {
                        Id = -1,
                        Megnevezes = ex.Message
                    };
                    return StatusCode(400, hiba);
                }
            }
        }

        [HttpGet("ToGyogyszerNevAsync")]
        public async Task<IActionResult> GetByNameAsync(string gynev)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = await context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Gyogyszer.Nev == gynev).Select(k => k.Betegseg).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> result = new List<Betegseg>();
                    result.Add(new Betegseg
                    {
                        Id = -1,
                        Megnevezes = ex.Message
                    });
                    return StatusCode(400, result);
                }
            }
        }

        [HttpGet("ToGyogyszerIdAsync")]
        public async Task<IActionResult> GetByIdToGyogyszerAsync(int id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Betegseg> result = await context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Gyogyszer.Id == id).Select(k => k.Betegseg).ToListAsync();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Betegseg> result = new List<Betegseg>();
                    result.Add(new Betegseg
                    {
                        Id = -1,
                        Megnevezes = ex.Message
                    });
                    return StatusCode(400, result);
                }
            }
        }

        [HttpGet("BetegsegDTOAsync")]
        public async Task<IActionResult> GetBetegsegDTOAsync()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<BetegsegDTO> result = await context.Betegsegs.Select(b => new BetegsegDTO()
                    {
                        Id = b.Id,
                        Megnevezes = b.Megnevezes,
                    }).ToListAsync();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<BetegsegDTO> result =
                    [
                        new BetegsegDTO
                        {
                            Id = -1,
                            Megnevezes = ex.Message
                        },
                    ];
                    return StatusCode(400, result);
                }
            }
        }

        [HttpPost("UjbetegsegAsync")]
        public async Task<IActionResult> Post(Betegseg betegseg)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    await context.Betegsegs.Add(betegseg);
                    context.SaveChanges();
                    return Ok("Sikeres rögzítés");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        [HttpDelete("TorlesBetegsegAsync")]
        public async Task<IActionResult> Delete(int Id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Betegseg torlendo = new Betegseg()
                    {
                        Id = Id,
                    };
                    context.Betegsegs.Remove(torlendo);
                    context.SaveChanges();
                    return Ok("Sikeres törlés!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("ModositBetegsegAsync")]
        public async Task<IActionResult> Put(Betegseg ujBetegseg)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    if (context.Betegsegs.Contains(ujBetegseg))
                    {
                        await context.Betegsegs.Update(ujBetegseg);
                        context.SaveChanges();
                        return Ok("Sikeres módosítás!");
                    }
                    else
                    {
                        return NotFound("Nincs ilyen elem!");
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion
    }
}
