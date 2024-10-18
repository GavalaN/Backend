using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace TestLogin_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            WebHttpBinding webHttpBinding = new WebHttpBinding();
            using (ServiceHost host = new ServiceHost(typeof(TestLogin_Server.Service1), uri))
            {
                webHttpBinding.CrossDomainScriptAccessEnabled = true;
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(TestLogin_Server.IService1), webHttpBinding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                ServiceEndpoint endpoint1 = host.AddServiceEndpoint(typeof(TestLogin_Server.IService1), basicHttpBinding, "soap");
                host.Authorization.ServiceAuthorizationManager = new MyServiceAuthorizationManager();
                host.Open();
                Console.WriteLine($"A szerver elindult: {DateTime.Now}");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
