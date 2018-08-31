/*
 * Auteur : Leandro Saraiva Maia
 * Titre : Calculatrice
 * Description : Permet de faire des calcul
 * Version : 1.0
*/

using System;

namespace testConsole
{
    class Program
    {
        #region private static variables
        private static float value1 = 0;
        private static float value2 = 0;
        private static string[] opList = { "+", "-", "/", "*" };
        private static char oper = ' ';
        private static float res = 0;
        private static string userValue = "";
        private static int i = 0;
        #endregion private static variables

        #region fonctions
        ///<summary>
        ///Fonction qui demande une valeur à l'utilisateur en testant les erreurs
        /// </summary>
        private static float askValue(bool WhatValue)
        {
            float val = 0;
            bool isValOk = false;
            string userVal = "";

            while (!isValOk)
            {
                if (WhatValue)
                {
                    Console.WriteLine("Entrer La premiere valeur");
                }
                else
                {
                    Console.WriteLine("Entrer La deuxieme valeur");
                }

                userVal = Console.ReadLine();
                isValOk = float.TryParse(userVal, out val);

                if (isValOk)
                {
                    return float.Parse(userVal);
                }
                else
                {
                    if (WhatValue)
                    {
                        Console.WriteLine("La premiere valeur est fausse\n");
                    }
                    else
                    {
                        Console.WriteLine("La deuxieme valeur est fausse\n");
                    }
                }
            }

            return 0;
        }

        ///<summary>
        ///Fonction qui effectue un calcul avec deux opérants et un opérateur
        /// </summary>
        private static float calcul(float val1, float val2, char op)
        {
            switch (op)
            {
                case '+': return val1 + val2;
                case '-': return val1 - val2;
                case '/':
                    //Evite la division par zéro
                    if (val2 == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return val1 / val2;
                    }
                case '*': return val1 * val2;
                default: return 0;
            }
        }
        #endregion fonctions

        #region main loop
        /// <summary>
        /// Cette fonction est défini comme le point d'entrée
        /// </summary>
        static void Main(string[] args)
        {
            while (true)
            {

                //Nettoye la console
                Console.Clear();

                userValue = Console.ReadLine();

                //Demande les valeurs à l'utilisateur
                value1 = askValue(true);

                Console.WriteLine("Entrer l'opérateur");
                userValue = Console.ReadLine();
                for (i = 0; i < opList.Length; i++) {
                    if (userValue == opList[i])
                    {
                        oper = char.Parse(opList[i]);
                        break;
                    }
                }

                value2 = askValue(false);

                //Effectue l'opération
                res = calcul(value1, value2, oper);

                //Affiche le résultat
                Console.WriteLine("Resultat : " + res);
                Console.Write("\n\nAppuyer sur une touche pour continuer");
                Console.ReadLine();
            }
        }
        #endregion main loop
    }
}
