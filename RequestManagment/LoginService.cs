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
                default:
                    return MessageGenerator.GenerateError(message, $"Unrecognized operation name! {message.OperationName}");
            }
        }

        private Msg LogUser(Msg message)
        {
            // Opérations de login

            businessAccessManager.ProcessMessage(message);

            // Opération 2...
            businessAccessManager.ProcessMessage(message);


            return message;
        }
    }
}
