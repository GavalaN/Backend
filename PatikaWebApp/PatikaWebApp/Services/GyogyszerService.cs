using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services
{
    public class GyogyszerService
    {
        
        public static List<Gyogyszer> GetGyogyszerekList()
        {
            using (var context = new PatikaContext())
            {
                try
                {
                    var response = context.Gyogyszers.ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<Gyogyszer> respons = new List<Gyogyszer>();
                    respons.Add(new Gyogyszer()
                    {
                        Id = -1,
                        Nev = ex.Message,
                    });
                    return respons;
                }
            }
        }


    }
}
