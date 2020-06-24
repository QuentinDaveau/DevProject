using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetDev.WCF.Service
{
    [ServiceContract(Namespace = "http://ProjetDev.WCF.Service")]
    public interface IRequestService
    {
        [OperationContract]
        Msg Request(Msg message);
    }
}
