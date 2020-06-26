using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestServiceClient client = new RequestServiceClient();

            string b = "";

            while(b != "exit")
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine();

                CommunicationParameters.Msg message = new CommunicationParameters.Msg()
                {
                    AppVersion = "0.1",
                    OperationName = "LogUser",
                    OperationType = "Login",
                    Data = new object[] { username, password },
                    TokenApp = "ThisIsATest",
                };

                CommunicationParameters.Msg response = client.Request(message);

                Console.WriteLine($"Réponse du serveur: Status({response.StatutOp}), Info({response.Info}), Data({response.Data[0]})\n");
                Console.WriteLine($"Taper 'exit' pour quitter");

                b = Console.ReadLine();
            }

            
        }
    }
}
