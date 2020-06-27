using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.CommunicationParameters;
using ProjetDev.WCF.RequestManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetDev.WCF.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RequestService : IRequestService
    {
        private readonly BusinessAccessManager businessAccessManager;
        private readonly RequestManager requestManager;

        public RequestService()
        {
            businessAccessManager = new BusinessAccessManager();
            requestManager = new RequestManager(businessAccessManager);
        }


        public Msg Request(Msg message)
        {
            return requestManager.ProcessMessage(message);
        }
    }
}
