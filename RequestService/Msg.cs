using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Service
{
    // Contrat de données de message de base qui va être utilisé dans l'entièreté de l'application
    [DataContract]
    public class Msg
    {
        bool statutOp;
        string info;
        object[] data;
        string operationName;
        string tokenApp;
        string tokenUser;
        string appVersion;
        string operationVersion;

        [DataMember]
        public bool StatutOp { get => statutOp; set => statutOp = value; }
        [DataMember]
        public string Info { get => info; set => info = value; }
        [DataMember]
        public object[] Data { get => data; set => data = value; }
        [DataMember]
        public string OperationName { get => operationName; set => operationName = value; }
        [DataMember]
        public string TokenApp { get => tokenApp; set => tokenApp = value; }
        [DataMember]
        public string TokenUser { get => tokenUser; set => tokenUser = value; }
        [DataMember]
        public string AppVersion { get => appVersion; set => appVersion = value; }
        [DataMember]
        public string OperationVersion { get => operationVersion; set => operationVersion = value; }
    }
}
