using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Business
{
    delegate void TaskCompletedCallBack(string taskResult, string key);
    class DecryptManager : IMessageReceiver
    {
        private TaskCompletedCallBack taskCompleted;

        public DecryptManager()
        {
            taskCompleted = new TaskCompletedCallBack(TaskCompleted);
        }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "DecryptFile":
                    return DecryptFile(message);
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName}: Unrecognized operation name", this.GetType().ToString());
            }
        }

        private Msg DecryptFile(Msg message)
        {
            // Pour le moment le DecryptManager ne garde pas en référence le message (et donc l'utilisateur) original. Il faudra le passer malgré tout d'une manière ou une autre.
            try
            {
                Parallel.Invoke(() =>
                {
                    new Decryptor((string)message.Data[1], taskCompleted);
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            return MessageGenerator.Validate(message);
        }

        private void TaskCompleted(string taskResult, string key)
        {
            // A implémenter: appel du service Java pour vérification
            Console.WriteLine($"Clé testée: {key}");
        }
    }
}
