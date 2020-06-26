using ProjetDev.WCF.Business;
using ProjetDev.WCF.CommunicationParameters;
using System;

namespace ProjetDev.WCF.BusinessAccess
{
    public class BusinessAccessManager: IMessageReceiver
    {
        private QueryManager queryManager;
        private LoginManager loginManager;

        public BusinessAccessManager()
        {
            queryManager = new QueryManager();
            loginManager = new LoginManager(queryManager);
        }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "LogUser":
                    return loginManager.ProcessMessage(MessageGenerator.SetOperation(message, "LogUser"));
                case "CheckToken":
                    return loginManager.ProcessMessage(MessageGenerator.SetOperation(message, "CheckToken"));
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName}: Unrecognized operation name", this.GetType().ToString());
            }
        }
    }
}
