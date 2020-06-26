using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.CommunicationParameters;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.RequestManagment
{
    public class LoginService : IMessageReceiver
    {
        private readonly BusinessAccessManager businessAccessManager;

        public LoginService(BusinessAccessManager businessAccessManager)
        {
            this.businessAccessManager = businessAccessManager;
        }


        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "LogUser":
                    return LogUser(message);
                case "CheckToken":
                    return CheckToken(message);
                default:
                    return MessageGenerator.GenerateError(message, $"Unrecognized operation name! {message.OperationName}", this.GetType().ToString());
            }
        }

        private Msg LogUser(Msg message)
        {
            return businessAccessManager.ProcessMessage(message);
        }

        private Msg CheckToken(Msg message)
        {
            return businessAccessManager.ProcessMessage(message);
        }
    }
}
