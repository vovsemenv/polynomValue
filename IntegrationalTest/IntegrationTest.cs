using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using polynomValue;
namespace IntegrationalTest
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void solveTest()
        {
            var inputData = new Dictionary<double,string>(){
                [-67] = "-12x3+3x2+5x+7",
                [23] = "+23",
                [-2869983] ="-99999x5+9999x3+9999x2+99999x+9999",
            };
            foreach (var testRow in inputData) {
                var coefs = ParseModule.parseAll(testRow.Value);
                var rez = ComputingModule.calculatePolynom(coefs,2);
                Assert.AreEqual(testRow.Key, rez);
            }
        }
    }
}
