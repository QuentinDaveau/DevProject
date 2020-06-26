using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.CommunicationParameters
{
    public static class MessageGenerator
    {
        public static Msg UpdateMessage(Msg sourceMessage, Dictionary<string, object> paramsToChange)
        {
            Msg newMessage = sourceMessage;
            foreach (KeyValuePair<string, object> pair in paramsToChange)
            {
                switch(pair.Key)
                {
                    case "statutOp":
                        newMessage.StatutOp = (bool)pair.Value;
                        break;
                    case "info":
                        newMessage.Info = (string)pair.Value;
                        break;
                    case "data":
                        newMessage.Data = (object[])pair.Value;
                        break;
                    case "operationName":
                        newMessage.OperationName = (string)pair.Value;
                        break;
                    case "tokenApp":
                        newMessage.TokenApp = (string)pair.Value;
                        break;
                    case "tokenUser":
                        newMessage.TokenUser = (string)pair.Value;
                        break;
                    case "appVersion":
                        newMessage.AppVersion = (string)pair.Value;
                        break;
                    case "operationVersion":
                        newMessage.OperationVersion = (string)pair.Value;
                        break;
                    case "operationType":
                        newMessage.OperationType = (string)pair.Value;
                        break;
                }
            }
            return newMessage;
        }

        public static Msg GenerateError(Msg sourceMessage, string errorInfo, string sourceClassName)
        {
            Msg newMessage = sourceMessage;
            newMessage.StatutOp = false;
            newMessage.Info = $"{sourceClassName}: {errorInfo}";
            return newMessage;
        }

        public static Msg SetOperation(Msg sourceMessage, string operationName)
        {
            Msg newMessage = sourceMessage;
            newMessage.OperationName = operationName;
            return newMessage;
        }

        public static Msg SetData(Msg sourceMessage, object[] data)
        {
            Msg newMessage = sourceMessage;
            newMessage.Data = data;
            return newMessage;
        }

        public static Msg SetInfo(Msg sourceMessage, string info)
        {
            Msg newMessage = sourceMessage;
            newMessage.Info = info;
            return newMessage;
        }

        public static Msg Validate(Msg sourceMessage)
        {
            Msg newMessage = sourceMessage;
            newMessage.StatutOp = true;
            return newMessage;
        }
    }
}
