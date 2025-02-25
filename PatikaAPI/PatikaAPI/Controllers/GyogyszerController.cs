﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaAPI.Models;
using PatikaAPI.DTOs;

namespace PatikaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GyogyszerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new PatikaContext())
            {
                try
                {
                    List<Gyogyszer> result = context.Gyogyszers.ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Gyogyszer> result = new List<Gyogyszer>();
                    Gyogyszer hiba = new Gyogyszer()
                    {
                        Id = -1,
                        Nev = ex.Message
                    };
                    result.Add(hiba);
                    return BadRequest(result);

                }
            }
        }

        [HttpGet("ById")]
        public IActionResult Get(int bid)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Gyogyszer result = context.Gyogyszers.FirstOrDefault(x => x.Id == bid);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    Gyogyszer hiba = new Gyogyszer()
                    {
                        Id = -1,
                        Nev = ex.Message
                    };               
                    return BadRequest(hiba);

                }
            }
        }

        [HttpGet("ToBetegsegName")]
        public IActionResult Get(string bname)
        {
            using(var context = new PatikaContext())
            {
                try
                {
                    List<Gyogyszer> result = context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Betegseg.Megnevezes == bname).Select(k => k.Gyogyszer).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Gyogyszer> result = new List<Gyogyszer>();
                    Gyogyszer hiba = new()
                    {
                        Id = -1,
                        Nev = ex.Message
                    };
                    result.Add(hiba);
                    return BadRequest(result);
                }
            }
        }

        [HttpGet("ToBetegsegId")]
        public IActionResult GetById(int id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<Gyogyszer> result = context.Kezels.Include(k => k.Gyogyszer).Include(k => k.Betegseg).Where(k => k.Betegseg.Id == id).Select(k => k.Gyogyszer).ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    List<Gyogyszer> result = new List<Gyogyszer>();
                    Gyogyszer hiba = new()
                    {
                        Id = -1,
                        Nev = ex.Message
                    };
                    result.Add(hiba);
                    return BadRequest(result);
                }
            }
        }

        [HttpGet("GyogyszerDTO")]
        public IActionResult GetGyogyszerDTO()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    List<GyogyszerNevHatoanyagDTO> result = context.Gyogyszers.Select(gy => new GyogyszerNevHatoanyagDTO() {
                    Id = gy.Id,
                    Nev = gy.Nev,
                    Hatoanyag = gy.Hatoanyag,
                    }).ToList();
                    return StatusCode(200,result);
                }
                catch (Exception ex)
                {
                    List<GyogyszerNevHatoanyagDTO> hibalista = new List<GyogyszerNevHatoanyagDTO>();
                    GyogyszerNevHatoanyagDTO hibaDTO = new GyogyszerNevHatoanyagDTO()
                    {
                        Id = -1,
                        Nev = ex.Message
                    };
                    hibalista.Add(hibaDTO);
                    return BadRequest(hibalista);
                }
            }
        }

        [HttpPost("Ujgyogyszer")]
        public IActionResult Post(Gyogyszer gyogyszer)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    context.Gyogyszers.Add(gyogyszer);
                    context.SaveChanges();
                    return Ok("Sikeres rögzítés");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            
        }

        [HttpDelete("TorlesGyogyszer")]
        public IActionResult Delete(int Id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    Gyogyszer torlendo = new Gyogyszer()
                    {
                        Id = Id,
                    };
                    context.Gyogyszers.Remove(torlendo);
                    context.SaveChanges();
                    return Ok("Sikeres törlés!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("ModositGyogyszer")]
        public IActionResult Put(Gyogyszer ujgyogyszer)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    if (context.Gyogyszers.Contains(ujgyogyszer))
                    {
                        context.Gyogyszers.Update(ujgyogyszer);
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
    }
}
