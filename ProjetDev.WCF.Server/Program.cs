using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.RequestManagment;
using ProjetDev.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessAccessManager businessAccessManager = new BusinessAccessManager();
            RequestManager requestManager = new RequestManager(businessAccessManager);
            RequestService requestService = new RequestService(requestManager);
            
        }
    }
}
