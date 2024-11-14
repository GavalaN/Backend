using Microsoft.EntityFrameworkCore;
using Zenebona.Models;

namespace Zenebona.Services
{
    public class KiadoService
    {
        public static List<Kiado> GetKiadok()
        {
            var context = new ZeneszamokContext();
            try
            {
                var response = context.Kiadok.ToList();
                return response;
            }
            catch (Exception ex)
            {
                List<Kiado> hiba = new List<Kiado>();
                hiba.Add(new Kiado()
                {
                    Id = -1,
                    Nev = ex.Message
                });
                return hiba;
            }
        }
    }
}
