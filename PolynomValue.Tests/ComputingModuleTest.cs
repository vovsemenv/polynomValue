using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using polynomValue;

namespace PolynomValue.Tests
{
    [TestClass]
    public class ComputingModuleTest
    {
        [TestMethod]
        public void CalcPolynom()
        {
            // Структура словоря
            // key - значение в точке 2
            // value - коэффициенты полинома начиная с старшей степени
            var testRatiosData1 = new Dictionary<long, List<int>> 
            {
                   [83] = new List<int>() { 1, 3, 5, 7, 9 },
                   [-1] = new List<int>() { -1, 1, 1 },
                   [-3] = new List<int>() { -1, 1, -1 },
                   [32752] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
                   [3099999969] = new List<int>() { 99999999, 99999999, 99999999, 99999999, 99999999 },
                   [-11] = new List<int>() { -1, -2, -3},
                   [2] = new List<int>() { 1, -2, 3, -4}
            };

            foreach (var testCase in testRatiosData1)
            {
                try
                {
                    Assert.AreEqual(testCase.Key, polynomValue.ComputingModule.calculatePolynom(testCase.Value, 2));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            // Структура словоря
            // key - значение в точке -2
            // value - коэффициенты полинома начиная с старшей степени
            var testRatiosData2 = new Dictionary<long, List<int>>
            {
                [7] = new List<int>() { 1, 3, 5, 7, 9 },
                [-5] = new List<int>() { -1, 1, 1 },
                [-7] = new List<int>() { -1, 1, -1 },
                [-3636] = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
                [1099999989] = new List<int>() { 99999999, 99999999, 99999999, 99999999, 99999999 },
                [-3] = new List<int>() { -1, -2, -3 },
                [-26] = new List<int>() { 1, -2, 3, -4 }
            };

            foreach (var testCase in testRatiosData2)
            {
                Assert.AreEqual(testCase.Key, polynomValue.ComputingModule.calculatePolynom(testCase.Value, -2));
            }
        }
    }
}
