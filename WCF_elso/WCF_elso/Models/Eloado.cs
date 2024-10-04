using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_elso_server.Models
{
    [DataContract]
    public class Eloado
    {
        [DataMember]
        public int eloadoAz { get; set; }
        [DataMember]
        public string eloadoName { get; set; }

        public override string ToString()
        {
            return eloadoAz+";"+eloadoName;
        }
    }
}