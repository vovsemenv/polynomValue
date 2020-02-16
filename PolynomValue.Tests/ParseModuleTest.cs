using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using polynomValue;

namespace PolynomValue.Tests
{
    [TestClass]
    public class ParseModuleTest
    {
        [TestMethod]
        public void ParceOperand()
        {
            Assert.AreEqual((3, 2), polynomValue.ParseModule.parseOperand("+2x3"));
            Assert.AreEqual((3, -2), polynomValue.ParseModule.parseOperand("-2x3"));

            Assert.AreEqual((4, 2), polynomValue.ParseModule.parseOperand("2x4"));
            Assert.AreEqual((4, -2), polynomValue.ParseModule.parseOperand("-2x4"));

            Assert.AreEqual((4, 12), polynomValue.ParseModule.parseOperand("12x4"));
            Assert.AreEqual((4, -12), polynomValue.ParseModule.parseOperand("-12x4"));

            Assert.AreEqual((1, 12), polynomValue.ParseModule.parseOperand("+12x1"));
            Assert.AreEqual((1, -12), polynomValue.ParseModule.parseOperand("-12x1"));
        }
    
        [TestMethod]
        public void OperandsFromString()
        {
            var testPolynoms = new Dictionary<string, List<string>>()
            {
                ["5"] = new List<string>() { "+5" },
                ["-5"] = new List<string>() { "+-5" },
                ["x+5"] = new List<string>() { "+x", "+5" },
                ["2x2+3x+5"] = new List<string>() { "+2x2", "+3x", "+5" },
                ["-2x2+3x+5"] = new List<string>() { "+-2x2", "+3x", "+5" },
                ["-12x2+3x+5"] = new List<string>() { "+-12x2", "+3x", "+5" },
                ["-12x3+3x2+5x+7"] = new List<string>() { "+-12x3", "+3x2", "+5x", "+7" },
            };

            foreach (var testCase in testPolynoms)
            {
                Assert.AreEqual(
                    string.Join("", testCase.Value.ToArray()), 
                    string.Join("", ParseModule.operandsFromString(testCase.Key).ToArray())
                );
            }
        }
    }
}
