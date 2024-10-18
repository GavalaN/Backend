using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestLogin_Server.Controllers;
using TestLogin_Server.Interfaces;
using TestLogin_Server.Models;

namespace TestLogin_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Felhasznalo> FelhasznaloLista()
        {
            List<Rekord> rlist = new FelhasznaloController().Select();
            List<Felhasznalo> flist = new List<Felhasznalo>();
            foreach (Rekord rekord in rlist)
            {
                flist.Add(rekord as Felhasznalo);
            }
            return flist;
        }

        public List<Jogosultsag> JogosultsagLista()
        {
            List<Rekord> rlist = new JogosultsagController().Select();
            List<Jogosultsag> jlist = new List<Jogosultsag>();
            foreach (Rekord rekord in rlist)
            {
                jlist.Add(rekord as Jogosultsag);
            }
            return jlist;
        }

        public string ModositFelhasznalo(Felhasznalo felhasznalo)
        {
            return "";
        }

        public string ModositJogosultsag(Jogosultsag jogosultsag)
        {
            return "";
        }

        public string TorolFelhasznalo(int id)
        {
            return "";
        }

        public string TorolJogosultsag(int id)
        {
            return "";
        }

        public string UjFelhasznalo(Felhasznalo felhasznalo)
        {
            return new FelhasznaloController().Insert(felhasznalo);
        }

        public string UjJogosultsag(Jogosultsag jogosultsag)
        {
            return "";
        }
    }
}
