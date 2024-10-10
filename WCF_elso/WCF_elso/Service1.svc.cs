using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_elso_server.Controllers;
using WCF_elso_server.Models;

namespace WCF_elso_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public CD GetCD()
        {
            CD cd = new CD()
            {
                CdAz = 1,
                CdCim = "Certified Lover Boy",
                Kiado = "O&T arnot"
            };
            return cd;
        }

        public List<Eloado> GetEloado()
        {
           
            List<Eloado> eloado = new EloadoController().EloadoLista();
            return eloado;
        }

        public string GetEloadoName()
        {
            Eloado eloado1 = new Eloado()
            {
                eloadoAz = 1,
                eloadoName = "Queen"
            };
            return eloado1.eloadoName;
        }

        public List<Zeneszam> GetZeneszam()
        {
            List <Zeneszam> zeneszam = new ZeneszamController().ZeneszamLista();
            return zeneszam;
        }
 


        public string ModositEloado(Eloado eloado)
        {
            return new EloadoController().InsertEloado(eloado);
        }

        public string ModositZeneszam(Zeneszam zeneszam)
        {
            return new ZeneszamController().UpdateZeneszam(zeneszam);
        }

        public string TorolElado(Eloado elado)
        {
            return new EloadoController().DeleteElado(elado);
        }

        public string TorolZeneszam(Zeneszam zeneszam)
        {
            return new ZeneszamController().DeleteZeneszam(zeneszam);  
        }

        public string UjEloado(Eloado ujEloado)
        {
            return new EloadoController().InsertEloado(ujEloado);
        }

        public string UjZeneszam(Zeneszam UjZeneszam)
        {
            return new ZeneszamController().InsertZeneszam(UjZeneszam);
        }
    }
}
