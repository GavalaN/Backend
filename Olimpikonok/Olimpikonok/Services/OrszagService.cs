using Microsoft.AspNetCore.Mvc;
using Olimpikonok.DTOs;
using Olimpikonok.Models;

namespace Olimpikonok.Services
{
    public class OrszagService
    {
        public static List<Orszag> GetOrszagokList()
        {
            using (var context = new OlimpikonokContext())
            {
                try
                {
                    var response = context.Orszags.ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Orszag> respons = new List<Orszag>();
                    respons.Add(new Orszag()
                    {
                        Id = -1,
                        Nev = ex.Message,
                    });
                    return respons;
                }
            }
        }

        public static Orszag GetOrszagByID(int id)
        {
            try
            {
                using (var context = new OlimpikonokContext())
                {
                    var response = context.Orszags.Where(o => o.Id == id).Select(o => new Orszag()
                    {
                        Id = o.Id,
                        Nev = o.Nev,
                        Fovaros = o.Fovaros,
                        Nepesseg = o.Nepesseg,
                    }).ToList();
                    return response[0];
                }
            }
            catch (Exception ex)
            {
                Orszag hibas = new()
                {
                    Id = -1,
                    Nev = $"Hibás kérés. {ex.Message}"
                };
                return hibas;
            }
        }
    }
}
