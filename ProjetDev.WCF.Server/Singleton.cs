using ProjetDev.WCF.BusinessAcess;
using ProjetDev.WCF.Service;
using ProjetDev.WCF.RequestManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Server
{
    public sealed class FactorySingleton
    {
        private static FactorySingleton instance = null;
        private static readonly object padlock = new object();

        FactorySingleton()
        {
        }

        public static FactorySingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FactorySingleton();
                    }
                    return instance;
                }
            }
        }

        public object GetClass(Type classType)
        {
            // Bon alors la conversion en string est dégeulasse, je sais...
            switch (classType.ToString())
            {
                case "RequestService":
                    break;
                case "BusinessAccessManager":
                    break;
                case "QueryManager":
                    break;
                case "ServiceAccessManager":
                    break;
                case "DecryptService":
                    break;
                case "CompletedDecryptionService":
                    break;
                case "LoginService":
                    break;
            }
            return null;
        }
    }
}
