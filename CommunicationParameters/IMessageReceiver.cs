using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDev.WCF.CommunicationParameters
{
    public interface IMessageReceiver
    {
        Msg ProcessMessage(Msg message);
    }
}
