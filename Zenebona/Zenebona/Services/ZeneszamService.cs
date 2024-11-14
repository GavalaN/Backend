using Microsoft.EntityFrameworkCore;
using Zenebona.Models;

namespace Zenebona.Services
{
    public class ZeneszamService
    {
        public static List<Zeneszam> GetZeneszamok()
        {
            var context = new ZeneszamokContext();
            try
            {
                //var response = context.Zeneszamok.ToList();
                var response = context.Zeneszamok.Include(f => f.Kiado).Include(f => f.Eloado).ToList();
                return response;
            }
            catch (Exception ex)
            {
                List<Zeneszam> hiba = new List<Zeneszam>();
                hiba.Add(new Zeneszam() 
                { 
                    Id = -1, 
                    Nev = ex.Message 
                });
                return hiba;
            }
        }
    }
}
