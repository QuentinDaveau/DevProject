using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.RequestManagment;
using ProjetDev.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/ProjetDev.WCF.Service/");

            ServiceHost host = new ServiceHost(typeof(RequestService));

            try
            {
                host.AddServiceEndpoint(typeof(IRequestService), new BasicHttpBinding(), baseAddress + "RequestService/");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.HttpGetUrl = new Uri("http://localhost:8000/ProjetDev.WCF.Service/RequestService/");
                host.Description.Behaviors.Add(smb);


                host.Open();
                Console.WriteLine("Started host succesfully!");
                Console.WriteLine("Press enter to exit application");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                host.Abort();
            }
            Console.ReadLine();
        }
    }
}
