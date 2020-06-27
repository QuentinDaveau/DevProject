using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Client
{
    class Program
    {
        private static string userToken = "";
        static void Main(string[] args)
        {
            RequestServiceClient client = new RequestServiceClient();

            string b = "";

            while(b != "exit")
            {
                Console.WriteLine("Sélectionner une action: 'Login', 'Decrypt'");
                string q = Console.ReadLine();

                switch (q)
                {
                    case "Login":
                        //Console.WriteLine("Username: ");
                        //string username = Console.ReadLine();

                        //Console.WriteLine("Password: ");
                        //string password = Console.ReadLine();

                        CommunicationParameters.Msg message = new CommunicationParameters.Msg()
                        {
                            AppVersion = "0.1",
                            OperationName = "LogUser",
                            OperationType = "Login",
                            //Data = new object[] { username, password },
                            Data = new object[] { "Bob", "password" },
                            TokenApp = "ThisIsATest",
                        };

                        CommunicationParameters.Msg response = client.Request(message);

                        if (response.StatutOp)
                        {
                            userToken = (string)response.Data[0];
                        }

                        Console.WriteLine($"Réponse du serveur: Status({response.StatutOp}), Info({response.Info}), Data({response.Data[0]})\n");
                        break;

                    case "Decrypt":
                        Console.WriteLine("Texte du fichier: ");
                        string text = Console.ReadLine();

                        CommunicationParameters.Msg m = new CommunicationParameters.Msg()
                        {
                            AppVersion = "0.1",
                            OperationName = "DecryptFile",
                            OperationType = "Decrypt",
                            Data = new object[] { "This is a test name", text },
                            TokenApp = "ThisIsATest",
                            TokenUser = userToken
                        };

                        CommunicationParameters.Msg r = client.Request(m);

                        Console.WriteLine($"Réponse du serveur: Status({r.StatutOp}), Info({r.Info}), Data({r.Data[0]})\n");
                        break;
                    default:
                        Console.WriteLine("Commande non reconnue");
                        break;
                }
                Console.WriteLine($"Taper 'exit' pour quitter ou entrer pour recommencer");

                b = Console.ReadLine();
            }
        }
    }
}
