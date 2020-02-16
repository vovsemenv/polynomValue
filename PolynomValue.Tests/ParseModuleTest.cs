using System;
using System.Collections.Generic;
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
    }
}
