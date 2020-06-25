using ProjetDev.WCF.Business;
using ProjetDev.WCF.CommunicationParameters;
using System;

namespace ProjetDev.WCF.BusinessAccess
{
    public class BusinessAccessManager: IMessageReceiver
    {
        private QueryManager queryManager = new QueryManager();
        private BusinessAccessManager businessAccessManager = new BusinessAccessManager();

        public Msg ProcessMessage(Msg message)
        {
            throw new NotImplementedException();
        }
    }
}
