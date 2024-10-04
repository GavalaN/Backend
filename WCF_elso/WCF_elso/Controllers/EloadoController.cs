using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WCF_elso_server.Models;

namespace WCF_elso_server.Controllers
{
    public class EloadoController
    {
        public List<Eloado> EloadoLista()
        {
            string[] sorok = File.ReadAllLines(@"C:\\Users\\Tanulo\\Downloads\\WCF_elso\\WCF_elso\\WCF_elso\\valami.txt");
            List<Eloado> list = new List<Eloado>();
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] bontas = sorok[i].Split(';');
                list.Add(new Eloado()
                {
                    eloadoAz = int.Parse(bontas[0]),
                    eloadoName = bontas[1]

                });

            }
            return list;
        }

        public string InsertEloado(Eloado ujEloado)
        {
            ujEloado.eloadoAz = General();
            StreamWriter sw = new StreamWriter(@"C:\\Users\\Tanulo\\Downloads\\WCF_elso\\WCF_elso\\WCF_elso\\valami.txt", true);
            sw.WriteLine(ujEloado.ToString());
            sw.Close();
            return "Sikeresen mentettük az előadót.";
        }

        int General()
        {
            return EloadoLista().Select(eloado => eloado.eloadoAz).ToList().Max() + 1;
        }

        public string UpdateElado(Eloado modositEloado)
        {
            //Beolvasok az állománybol egy listába
            List<Eloado> lista = EloadoLista();
            //Megkeresen az id-t, ha megtalálom módosítom az adatokat,
            int i = 0;
            while (i < lista.Count && lista[i].eloadoAz != modositEloado.eloadoAz)
            {
                i++;
            }
            if (i < lista.Count)
            {
                //és a módosított listával újra generálom az állományt
                StreamWriter sw = new StreamWriter(@"C:\\Users\\Tanulo\\Downloads\\WCF_elso\\WCF_elso\\WCF_elso\\valami.txt");
                sw.WriteLine("elozoAzon;eloadoName");
                foreach (var item in lista)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.Close();
                return "A módosítás sikeres";
                
            }
            else
            {
                //Ha nem találom akkor nem változtatok az állományon
                return "Nincs ilyen azonosítójú előadó";
            }
            
        }
        public string DeleteElado(Eloado torolEloado)
        {
            //Beolvasok az állománybol egy listába
            List<Eloado> lista = EloadoLista();
            //Megkeresen az id-t, ha megtalálom módosítom az adatokat,
            int i = 0;
            while (i < lista.Count && lista[i].eloadoAz != torolEloado.eloadoAz)
            {
                i++;
            }
            if (i < lista.Count)
            {
                //és a módosított listával újra generálom az állományt
                StreamWriter sw = new StreamWriter(@"C:\\Users\\Tanulo\\Downloads\\WCF_elso\\WCF_elso\\WCF_elso\\valami.txt");
                sw.WriteLine("elozoAzon;eloadoName");
                foreach (var item in lista)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.Close();
                return "A törlés sikeres";

            }
            else
            {
                //Ha nem találom akkor nem változtatok az állományon
                return "Nincs ilyen azonosítójú előadó";
            }

        }
    }
}