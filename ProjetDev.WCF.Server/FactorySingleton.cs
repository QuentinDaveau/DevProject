using ProjetDev.WCF.BusinessAccess;
using ProjetDev.WCF.RequestManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetDev.WCF.Business;


namespace ProjetDev.WCF.Server
{
    // Sert de warehouse accessible depuis l'ensemble du serveur et contenant les instances des classes principales.


    // Il se peut qu'il soit obsolète avec la nouvelle implémentation


    public sealed class FactorySingleton
    {
        //private static FactorySingleton instance = null;

        //private static readonly RequestManager requestManager = new RequestManager();
        //private static readonly BusinessAccessManager businessAccessManager = new BusinessAccessManager();
        //private static readonly QueryManager queryManager = new QueryManager();
        //private static readonly ServiceAccessManager serviceAccessManager = new ServiceAccessManager();


        //private static readonly object padlock = new object();

        //FactorySingleton()
        //{
        //}

        //public static FactorySingleton Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new FactorySingleton();
        //            }
        //            return instance;
        //        }
        //    }
        //}

        //public object GetClass(Type classType)
        //{
        //    // Bon alors la conversion en string est dégeulasse, je sais...
        //    switch (classType.ToString())
        //    {
        //        case "RequestManager":
        //            return requestManager;
        //        case "BusinessAccessManager":
        //            return businessAccessManager;
        //        case "QueryManager":
        //            return queryManager;
        //        case "ServiceAccessManager":
        //            return serviceAccessManager;
        //    }
        //    return null;
        //}
    }
}
