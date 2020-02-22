using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using polynomValue;

namespace PolynomValue.SmokeTestUI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryOpentWindow()
        {
            MainWindow window = new MainWindow();
            window.InitializeComponent();
            window.Show();
            NUnit.Framework.Assert.IsTrue(window.IsVisible);
            window.Close();
            NUnit.Framework.Assert.IsFalse(window.IsVisible);
        }

        [TestMethod]
        [TestCase("1", "2")]
        public void CalcPolynomFirstTest(string exp, string arg)
        {
            MainWindow window = new MainWindow();
            window.InitializeComponent();
        }
    }
}
