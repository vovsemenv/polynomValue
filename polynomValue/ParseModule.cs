using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;

namespace polynomValue
{
    public class ParseModule
    {
        /// <summary>
        /// Совершает полное преобразование полинома в виде строки в список с коэфиентами расположеными по убыванию степени
        /// </summary>
        /// <param name="polynom"> строка вида 2x2+3x+5</param>
        /// <returns> список вида [2,3,5] </returns>
        public static List<int> parseAll(string polynom)
        {
            var operands = operandsFromString(polynom);
            var hash = new Hashtable();
            var newlist = new List<int>();
            int max = 0;

            foreach (var operand in operands)
            {

                var opdata = parseOperand(operand);
                if (opdata.Item1 > max)
                {
                    max = opdata.Item1;
                }

                hash.Add(opdata.Item1, opdata.Item2);

            }

            var s = new List<int>();
            for (int i = 0; i < max + 1; i++)
            {
                newlist.Add(0);
            }
            foreach (DictionaryEntry item in hash)
            {
                newlist[int.Parse(item.Key.ToString())] = int.Parse(item.Value.ToString());
            }

            newlist.Reverse();

            return newlist;
        }


        /// <summary>
        /// Преобразует строкуи из формы в список операндов
        /// </summary>
        /// <param name="str">Строка вида 2x2+3x+5</param>
        /// <returns>Возвращаяет список операндов вида [ "+2x+2","2x","5"] </returns>
        public static List<string> operandsFromString(string str)
        {
            if (str[0] != '+' || str[0] != '-')
            {
                str = '+' + str;
            }

            string pattern = @"(\+)|(\-)";
            var aga = Regex.Split(str, pattern);
            var reg = new List<String>(aga);
            reg.RemoveAt(0);


            var newlist = new List<string>();

            var temp = "";
            for (int i = 0; i < reg.Count; i++)
            {
                temp += reg[i];
                if (i % 2 != 0)
                {
                    newlist.Add(temp);
                    temp = "";
                }
            }
            return newlist;

        }

        /// <summary>
        /// Преобразует опперанд извлекая из него коэфицент и степень
        /// </summary>
        /// <param name="operand">Пример: строка вида "+2x3" </param>
        /// <returns>Возвращает тюпл содеражащий степень и коэфицент из операнда  Пример тюпл вида (3 , 2)</returns>
        public static (int, int) parseOperand(string operand)
        {


            int pow = 0;
            int coef = 0;

            var newlist = operand.Split('x');

            coef = int.Parse(newlist[0]);
            if (newlist.Length == 2)
            {
                if (newlist[1] != "")
                {
                    pow = int.Parse(newlist[1]);
                }
                else
                {
                    pow = 1;
                }
            }
            else
            {
                pow = 0;
            }


            return (pow, coef);
        }
    }
}
