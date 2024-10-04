using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_elso_client.ServiceReference1;
using WCF_elso_server.Controllers;
using WCF_elso_server.Models;

namespace WCF_elso_client
{
    internal class Program
    {
        static Service1Client client;
        static void Main(string[] args)
        {
            client = new Service1Client();
            //List<ServiceReference1.Eloado> eloados = EloadoController.EloadoLista();
            //Eloado eloado = client.GetEloado();
            CD cd = client.GetCD();
            Console.WriteLine(cd.CdCim);
            //Console.WriteLine(eloado.eloadoName);
            Console.ReadKey();
        }
    }
}
