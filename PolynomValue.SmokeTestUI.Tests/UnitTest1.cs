using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using polynomValue;

namespace PolynomValue.SmokeTestUI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Description("Попытка открыть и закрыть приложение")]
        public void TryOpentWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();
            NUnit.Framework.Assert.IsTrue(window.IsVisible);
            window.Close();
            NUnit.Framework.Assert.IsFalse(window.IsVisible);
        }

        [DataTestMethod]
        [Description("Проверка корректной работы UI для вычисление значения первого полинома P(x)")]
        [DataRow("1", 2, 1)]
        [DataRow("1", 999, 1)]
        [DataRow("1", -999, 1)]
        [DataRow("-1", -999, -1)]
        [DataRow("x+5", -2, 3)]
        [DataRow("x-5", -2, -7)]
        [DataRow("x2+x-5", -2, -3)]
        [DataRow("999x2-999x-999", -2, 4995)]
        public void CalcPolynomFirstTest(string exp, int operand, double expected)
        {
            MainWindow window = new MainWindow();

            window.setPx(exp);
            window.setX(operand);
            window.clickPx();

            Assert.AreEqual(expected, window.res);
        }

        [DataTestMethod]
        [Description("Проверка корректной работы UI для вычисление значения первого полинома Q(y)")]
        [DataRow("1", 2, 1)]
        [DataRow("1", 999, 1)]
        [DataRow("1", -999, 1)]
        [DataRow("-1", -999, -1)]
        [DataRow("x+5", -2, 3)]
        [DataRow("x-5", -2, -7)]
        [DataRow("x2+x-5", -2, -3)]
        [DataRow("999x2-999x-999", -2, 4995)]
        public void CalcPolynomSecondTest(string exp, int operand, double expected)
        {
            MainWindow window = new MainWindow();

            window.setQy(exp);
            window.setY(operand);
            window.clickQy();

            Assert.AreEqual(expected, window.res);
        }
    }
}
