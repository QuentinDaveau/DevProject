using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetDev.WCF.Business
{
    class KeyGen
    {
        private static string keyCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // KeyIncrement: compteur qui va définir la nouvelle clé à générer. Array de 6 int. Chaque int représente une lettre de l'alphabet (-1 = rien)
        // On incrémente à chaque fois le premier int. Si il vaut 26 (= z + 1), on le repasse à "A", et on incrémente le int suivant de 1.
        // {0, -1, -1, -1} = "A", {5, 2, 1, -1} = "FCB"...
        // Pour maximiser les perfs on passe directement par un array (dirty) plutôt que faire un modulo ou autre calcul mathématique.
        private int[] keyIncrement = new int[] { -1, -1, -1, -1};

        private string key = string.Empty;

        // Retourne la clé actuelle sous forme de string
        public string GetKey()
        {
            string returnString = "";
            foreach (int value in keyIncrement) returnString += " " + value + ",";
            return returnString;
        }

        // Génère une nouvelle clé. Incrémente la liste de 1, convertis les int en lettre de l'alphabet et retourne une liste binaire (la clé)
        public byte[] GenerageKey()
        {
            keyIncrement[0] += 1;

            if (keyIncrement[0] == 26)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (keyIncrement[i] == -1) continue;
                    if (keyIncrement[i] == 26)
                    {
                        keyIncrement[i] = 0;
                        keyIncrement[i + 1] += 1;
                    }
                }
            }

            key = string.Empty;

            foreach (int num in keyIncrement)
            {
                if (num == -1) continue;
                key += keyCharacters[num];
            }

            // Console.WriteLine(key);

            return Encoding.UTF8.GetBytes(key);
        }
    }
}
