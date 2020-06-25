using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.RequestManagment
{
    public class DecryptService : IMessageReceiver
    {
        private readonly BusinessAccessManager businessAccessManager;

        public DecryptService(BusinessAccessManager businessAccessManager)
        {
            this.businessAccessManager = businessAccessManager;
        }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "LogUser":
                    return LaunchDecrypt(message);
                default:
                    return MessageGenerator.GenerateError(message, $"Unrecognized operation name! {message.OperationName}");
            }
        }

        private Msg LaunchDecrypt(Msg message)
        {
            // Opération 1...
            businessAccessManager.ProcessMessage(message);

            return message;
        }
    }
}
