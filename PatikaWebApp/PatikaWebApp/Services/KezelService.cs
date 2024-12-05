using Microsoft.EntityFrameworkCore;
using PatikaWebApp.DTOs;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services
{
    public class KezelService
    {
        public static List<Kezel> KezelList()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    var response = context.Kezels.Include(k => k.Betegseg).Include(k => k.Gyogyszer).ToList();
                    return response.ToList();
                }
                catch (Exception)
                {
                    List<Kezel> respons = new List<Kezel>();
                    respons.Add(new Kezel(){
                        BetegsegId = -1,
                    });
                    return respons;
                }
            }
        }

        public static List<KezelDTO> KezelById(int Id)
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    var response = context.Kezels.Include(k => k.Betegseg).Include(k => k.Gyogyszer).Where(k => k.GyogyszerId == Id).Select(k => new KezelDTO
                    {
                        Betegseg_megnevezes = k.Betegseg.Megnevezes,
                        Leiras = k.Betegseg.Leiras,
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<KezelDTO> respons = new List<KezelDTO>();
                    respons.Add(new KezelDTO()
                    {
                        Leiras = ex.Message,
                    });
                    return respons;
                }
            }
        }
    }
}
