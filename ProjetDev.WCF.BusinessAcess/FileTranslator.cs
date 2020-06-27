using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.Business
{
    class FileTranslator
    {
        private byte[] bytesToDecrypt;
        private int byteLength;
        private TaskCompletedCallBack callback;

        // Définition du texte à décrypter à l'initialisation de la classe
        public FileTranslator(byte[] bytesToDecrypt, TaskCompletedCallBack callback)
        {
            this.callback = callback;
            this.bytesToDecrypt = bytesToDecrypt;
            byteLength = bytesToDecrypt.Length;
        }

        // Décryptage du texte en utilisant la clé donnée.
        public void DecryptWithKey(byte[] key)
        {
            byte[] result = new byte[byteLength];
            int keyLength = key.Length;

            for (int i = 0; i < byteLength; i++)
            {
                result[i] = (byte)(bytesToDecrypt[i] ^ key[i % keyLength]);
            }

            callback(Encoding.UTF8.GetString(result), Encoding.UTF8.GetString(key));
        }
    }
}
