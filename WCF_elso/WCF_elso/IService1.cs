using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.PeerResolvers;
using System.Text;
using WCF_elso_server.Models;
using WCF_elso_server.Controllers;

namespace WCF_elso_server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        //[WebGet(UriTemplate = "/GetEloado")]
        List<Eloado> GetEloado();
        [OperationContract]
        //[WebGet(UriTemplate = "/GetEloadoName")]
        string GetEloadoName();
        [OperationContract]
        //[WebGet(UriTemplate = "/GetZeneszam")]
        List<Zeneszam> GetZeneszam();
        [OperationContract]
        //[WebGet(UriTemplate = "/GetCD")]
        CD GetCD();
        [OperationContract]
        string UjEloado(Eloado ujEloado);
        [OperationContract]
        string ModositEloado(Eloado eloado);
        [OperationContract]
        string TorolElado(Eloado elado);
        [OperationContract]
        string UjZeneszam(Zeneszam UjZeneszam);
        [OperationContract]
        string ModositZeneszam(Zeneszam zeneszam);
        [OperationContract]
        string TorolZeneszam(Zeneszam zeneszam);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   

    public class CD
    {
        [DataMember]
        public int CdAz { get; set; }
        [DataMember]
        public string CdCim { get; set; }
        [DataMember]
        public string Kiado { get; set; }
    }
}
