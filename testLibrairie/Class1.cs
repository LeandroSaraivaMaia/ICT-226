/*
 * Author : Leandro Saraiva Maia
 * Title : Calculator
 * Description : Make a calculation with two operand and one operator
 * by asking the user for values
 * Version : 1.0
*/

using System;

namespace testLibrairie
{
    public class Calculator
    {
        #region private static variables
        private float value1 = 0;
        private float value2 = 0;
        private string[] opList = { "+", "-", "/", "*" };
        private char oper = ' ';
        private float res = 0;
        private string userValue = "";
        private int i = 0;
        #endregion private static variables

        #region fonctions
        ///<summary>
        ///Ask a value to the user and test error case
        ///</summary>
        private float askValue(bool WhatValue)
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
        ///Make a calculation with two operand and one operator
        ///</summary>
        public float calcul(float val1, float val2, char op)
        {
            switch (op)
            {
                case '+': return val1 + val2;
                case '-': return val1 - val2;
                case '/':
                    //Prevents divison by 0
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
        ///<summary>
        ///This function is designed to be then entry point
        ///</summary>
        void Main(string[] args)
        {
            while (true)
            {

                //Clean the console
                Console.Clear();

                userValue = Console.ReadLine();

                //Ask values to the user
                value1 = askValue(true);

                Console.WriteLine("Entrer l'opérateur");
                userValue = Console.ReadLine();
                for (i = 0; i < opList.Length; i++)
                {
                    if (userValue == opList[i])
                    {
                        oper = char.Parse(opList[i]);
                        break;
                    }
                }

                value2 = askValue(false);

                //Calculate
                res = calcul(value1, value2, oper);

                //Show the results
                Console.WriteLine("Resultat : " + res);
                Console.Write("\n\nAppuyer sur une touche pour continuer");
                Console.ReadLine();
            }
        }
        #endregion main loop
    }
}
