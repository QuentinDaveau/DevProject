using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.Business
{
    // Classe gérant la connexion avec la base de données, ainsi que le passage des requêtes.

    // Bon, SQL Server me casse les pieds, donc pour le moment la classe va simuler une BDD. J'aurais mieux fait d'installer un vieux MySQL ou wamp, ça aurai été plus simple

    public class DbConnector : IMessageReceiver
    {

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "SendQuery":
                    return SendQuery(message);
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName}: Unrecognized operation", this.GetType().ToString());
            }
        }

        private Msg SendQuery(Msg message)
        {
            switch (message.Data[0])
            {
                case "SELECT count(*) FROM users WHERE username = 'Bob' AND password = 'password'":
                    return MessageGenerator.UpdateMessage(message, new Dictionary<string, object>
                    {
                        {"data", new object[]{1}},
                        {"statutOp", true}
                    });
                case "SELECT count(*) FROM users WHERE username = 'Roger' AND password = 'password'":
                    return MessageGenerator.UpdateMessage(message, new Dictionary<string, object>
                    {
                        {"data", new object[]{0}},
                        {"statutOp", true}
                    });
                default:
                    return MessageGenerator.GenerateError(message, "Unrecognized query", this.GetType().ToString());
            }
        }
    }
}
