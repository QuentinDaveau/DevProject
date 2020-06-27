using ProjetDev.WCF.CommunicationParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetDev.WCF.Business
{
    class Decryptor
    {
        public Decryptor(string fileToDecrypt, TaskCompletedCallBack callback)
        {
            KeyGen keyGen = new KeyGen();
            FileTranslator fileTranslator = new FileTranslator(Encoding.UTF8.GetBytes(fileToDecrypt), callback);

            for (int i = 0; i < 1000; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    byte[] t = keyGen.GenerageKey();
                    byte[] k = new byte[t.Length];
                    t.CopyTo(k, 0);
                    fileTranslator.DecryptWithKey(k);
                });
            }
        }
    }
}
