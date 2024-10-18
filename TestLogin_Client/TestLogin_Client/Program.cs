using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogin_Client.ServiceReference1;

namespace TestLogin_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Felhasznalo> felhasznalok = new Service1Client().FelhasznaloLista().ToList();
            //List<Jogosultsag> jogosultsagok = new Service1Client().JogosultsagLista().ToList();
            foreach (var item in felhasznalok)
            {
                Console.WriteLine(item.Nev);
            }
            Console.ReadKey();
        }
    }
}
