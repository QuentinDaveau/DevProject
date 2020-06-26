using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetDev.WCF.Business
{
    // Classe gérant les requêtes d'accès à la base de données
    public class QueryManager : IMessageReceiver
    {
        private DbConnector dbConnector = new DbConnector();

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "FindUser":
                    return FindUser(message);
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName} Unrecognized operation name", this.GetType().ToString());
            }
        }

        private Msg FindUser(Msg message)
        {
            Msg newMessage = MessageGenerator.UpdateMessage(message, new Dictionary<string, object>
            {
                {"data", new object[]{ $"SELECT count(*) FROM users WHERE username = '{message.Data[0]}' AND password = '{message.Data[1]}'" }},
                {"operationName", "SendQuery"}
            });
            return dbConnector.ProcessMessage(newMessage);
        }
    }
}
