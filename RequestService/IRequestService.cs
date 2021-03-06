﻿using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetDev.WCF.Service
{
    [ServiceContract(Namespace = "http://ProjetDev.WCF.Service", SessionMode = SessionMode.Required)]
    public interface IRequestService
    {
        [OperationContract]
        Msg Request(Msg message);
    }
}
