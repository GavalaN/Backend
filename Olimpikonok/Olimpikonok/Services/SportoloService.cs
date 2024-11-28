using Microsoft.EntityFrameworkCore;
using Olimpikonok.DTOs;
using Olimpikonok.Models;

namespace Olimpikonok.Services
{
    public class SportoloService
    {
        //csinálunk olyat, amit nem szabad
        public static List<Sportolo> GetSportolokList()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var response = context.Sportolos.Include(s => s.Orszag).Include(s => s.Sportag).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Sportolo> respons = new List<Sportolo>();
                    respons.Add(new Sportolo()
                    {
                        Id = -1,
                        Nev = ex.Message,
                    });
                    return respons;
                }
            }
        }

        public static List<SportoloDTO> GetSportoloDTOList()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var response = context.Sportolos.Include(s => s.Orszag).Include(s => s.Sportag).Select(s => new SportoloDTO
                    {
                        Id = s.Id,
                        Nev = s.Nev,
                        Neme = s.Neme,
                        Szuldatum = s.Szuldatum,
                        SportagNev = s.Sportag.Megnevezes,
                        Ermek = s.Ermek,
                        IndexKep = s.IndexKep,
                        OrszagNev = s.Orszag.Nev,
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<SportoloDTO> respons = new List<SportoloDTO>();
                    respons.Add(new SportoloDTO()
                    {
                        Id = -1,
                        Nev = ex.Message,
                    });
                    return respons;
                }
            }
        }

        public static NagyKep GetNagyKep(int id)
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var response = context.Sportolos.Where(s => s.Id == id).Select(s => new NagyKep() { Kep = s.Kep }).ToList();
                    return response[0];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static SportoloDTO GetSportoloDTOByID(int id) 
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    var response = context.Sportolos.Where(s => s.Id == id).Select(s => new SportoloDTO()
                    {
                        Id = s.Id,
                        Nev = s.Nev,
                        Neme = s.Neme,
                        Szuldatum = s.Szuldatum,
                        Ermek = s.Ermek,
                        IndexKep = s.IndexKep,
                        SportagNev = s.Sportag.Megnevezes,
                        OrszagNev = s.Orszag.Nev,
                    }).ToList();
                    return response[0];
                }
            }
            catch (Exception ex)
            {
                SportoloDTO hibas = new()
                {
                    Id = -1,
                    Nev = $"Hibás kérés. {ex.Message}"
                };
                return hibas;
            }
        }
    }
}
