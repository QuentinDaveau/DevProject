using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.CommunicationParameters;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.RequestManagment
{
    public class CompletedDecryptionService : IMessageReceiver
    {
        private readonly BusinessAccessManager businessAccessManager;

        public CompletedDecryptionService(BusinessAccessManager businessAccessManager)
        {
            this.businessAccessManager = businessAccessManager;
        }

        public Msg ProcessMessage(Msg message)
        {
            throw new NotImplementedException();
        }
    }
}
