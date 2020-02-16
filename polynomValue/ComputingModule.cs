using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polynomValue
{
    class ComputingModule
    {
        /// <summary>
        ///     Функция вычисляет занчение полинома используя схему горнера 
        ///     https://www.math10.com/ru/vysshaya-matematika/horner.html
        /// </summary>
        /// <param name="ratios"> Принимает список коэфицентов начиная с наибольшей степени</param>
        /// <param name="coef">Принимает х для которго нужно вычислить значение</param>
        /// <returns>Возвращает вычисленное значение полинома</returns>
        public static int calculatePolynom(List<int> ratiosData, int coef)
        {
            var ratios = new List<int>(ratiosData);
            int res = ratios[0];
            ratios.RemoveAt(0);
            foreach (var ratio in ratios)
            {
                res = ratio + coef * res;
            }
            

            return res;
        }
        
    }
}
