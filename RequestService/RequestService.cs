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
    public class RequestService : IRequestService
    {
        private readonly RequestManager requestManager;
        public RequestService(RequestManager requestManager)
        {
            this.requestManager = requestManager;
        }


        public Msg Request(Msg message)
        {
            return requestManager.ProcessMessage(message);
        }
    }
}
