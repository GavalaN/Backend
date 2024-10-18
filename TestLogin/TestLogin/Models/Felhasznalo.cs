using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestLogin_Server.Models
{
    public class Felhasznalo : Rekord
    {
        [DataMember]
        public string LoginNev { get; set; }

        [DataMember]
        public string HASH { get; set; }

        [DataMember]
        public string SALT { get; set; }

        [DataMember]
        public string Nev { get; set;}

        [DataMember]
        public int Jog { get; set;}

        [DataMember]
        public bool Aktiv { get; set;}

        [DataMember]
        public string Email { get; set;}

        [DataMember]
        public string ProfilKep { get; set;}
    }
}