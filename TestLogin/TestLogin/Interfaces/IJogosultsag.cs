using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TestLogin_Server.Models;

namespace TestLogin_Server.Interfaces
{
    [ServiceContract]
    public interface IJogosultsag
    {
        [OperationContract]
        List<Jogosultsag> JogosultsagLista();

        [OperationContract]
        string UjJogosultsag(Jogosultsag jogosultsag);

        [OperationContract]
        string ModositJogosultsag(Jogosultsag jogosultsag);

        [OperationContract]
        string TorolJogosultsag(int id);
    }
}
