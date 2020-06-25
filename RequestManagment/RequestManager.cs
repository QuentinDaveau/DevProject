using System;
using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.CommunicationParameters;

namespace ProjetDev.WCF.RequestManagment
{
    public class RequestManager : IMessageReceiver
    {
        private readonly LoginService loginService;
        private readonly DecryptService decryptService;
        private readonly CompletedDecryptionService completedDecryptionService;
        private readonly BusinessAccessManager businessAccessManager;

        public RequestManager(BusinessAccessManager businessAccessManager)
        {
            this.businessAccessManager = businessAccessManager;
        }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationType)
            {
                case "Login":
                    return loginService.ProcessMessage(message);
                case "Decrypt":
                    return decryptService.ProcessMessage(message);
                case "DecryptDone":
                    return completedDecryptionService.ProcessMessage(message);
                default:
                    return MessageGenerator.GenerateError(message, "Unrecognized operation type!");
            }
        }
    }
}
