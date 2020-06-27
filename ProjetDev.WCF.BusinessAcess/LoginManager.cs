using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.Business
{
    public class LoginManager : IMessageReceiver
    {
        private QueryManager queryManager;
        private List<string> tokens;

        public LoginManager(QueryManager queryManager)
        {
            this.queryManager = queryManager;
            tokens = new List<string>();
        }

        public Msg ProcessMessage(Msg message)
        {
            switch (message.OperationName)
            {
                case "LogUser":
                    return LogUser(message);
                case "CheckToken":
                    return CheckToken(message);
                default:
                    return MessageGenerator.GenerateError(message, $"{message.OperationName}: Unrecognized operation name", this.GetType().ToString());
            }
        }

        private Msg LogUser(Msg message)
        {
            Msg answer = queryManager.ProcessMessage(MessageGenerator.SetOperation(message, "FindUser"));

            if (answer.StatutOp == false)
            {
                return answer;
            }
            if ((int)answer.Data[0] > 0)
            {
                Msg m = MessageGenerator.SetInfo(answer, "Login successful!");
                return LogInUser(m);
            }
            else
            {
                return MessageGenerator.GenerateError(message, $"{message.OperationName}: Invalid user credentials", this.GetType().ToString());
            }
        }

        // Vérifie si un token utilisateur est valide ou non
        private Msg CheckToken(Msg message)
        {
            try
            {
                if (tokens.Contains(message.TokenUser))
                {
                    return MessageGenerator.Validate(message);
                }
                else
                {
                    return MessageGenerator.GenerateError(message, "Invalid token", this.GetType().ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        // Génère un token utilisateur
        private Msg LogInUser(Msg message)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            tokens.Add(token);

            return MessageGenerator.SetData(message, new object[] { token });
        }
    }
}
