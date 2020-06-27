using ProjetDev.WCF.Business;
using ProjetDev.WCF.CommunicationParameters;
using System;

namespace ProjetDev.WCF.BusinessAccess
{
    public class BusinessAccessManager: IMessageReceiver
    {
        private QueryManager queryManager;
        private LoginManager loginManager;
        private DecryptManager decryptManager;

        public BusinessAccessManager()
        {
            queryManager = new QueryManager();
            loginManager = new LoginManager(queryManager);
            decryptManager = new DecryptManager();
    }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "LogUser":
                    return loginManager.ProcessMessage(MessageGenerator.SetOperation(message, "LogUser"));
                case "CheckToken":
                    return loginManager.ProcessMessage(MessageGenerator.SetOperation(message, "CheckToken"));
                case "DecryptFile":
                    return decryptManager.ProcessMessage(MessageGenerator.SetOperation(message, "DecryptFile"));
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName}: Unrecognized operation name", this.GetType().ToString());
            }
        }
    }
}
