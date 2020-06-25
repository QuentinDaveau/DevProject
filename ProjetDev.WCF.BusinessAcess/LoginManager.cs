using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.Business
{
    class LoginManager : IMessageReceiver
    {
        public Msg ProcessMessage(Msg message)
        {
            // Gère le login
            return message;
        }
    }
}
