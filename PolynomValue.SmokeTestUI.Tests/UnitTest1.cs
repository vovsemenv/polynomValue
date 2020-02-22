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
            Assert.IsTrue(window.IsVisible);
            window.Close();
            Assert.IsFalse(window.IsVisible);
        }

        [TestMethod]
        [Description("Попытка записать значение аргуместа Y")]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(2222, 2222)]
        [DataRow(-1, -1)]
        [DataRow(-2, -2)]
        [DataRow(-2222, -2222)]
        public void SetSecondOperand(int operand, int expected)
        {
            MainWindow window = new MainWindow();
            window.Show();

            window.setY(operand);
            Assert.AreEqual(expected, window.getY());

            window.Close();
        }

        [TestMethod]
        [Description("Попытка записать значение аргуместа X")]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(2222, 2222)]
        [DataRow(-1, -1)]
        [DataRow(-2, -2)]
        [DataRow(-2222, -2222)]
        public void SetFirstOperand(int operand, int expected)
        {
            MainWindow window = new MainWindow();
            window.Show();

            window.setX(operand);
            Assert.AreEqual(expected, window.getX());

            window.Close();
        }

        [TestMethod]
        [Description("Попытка записать выражение для P(x)")]
        [DataRow("", "")]
        [DataRow("1", "1")]
        [DataRow("x", "x")]
        [DataRow("-x", "-x")]
        [DataRow("x2-x", "x2-x")]
        [DataRow("x2", "x2")]
        public void SetFirstExp(string exp, string expected)
        {
            MainWindow window = new MainWindow();
            window.Show();

            window.setPx(exp);
            Assert.AreEqual(expected, window.getPx());

            window.Close();
        }

        [TestMethod]
        [Description("Попытка записать выражение для Q(y)")]
        [DataRow("", "")]
        [DataRow("1", "1")]
        [DataRow("x", "x")]
        [DataRow("-x", "-x")]
        [DataRow("x2-x", "x2-x")]
        [DataRow("x2", "x2")]
        public void SetSecondExp(string exp, string expected)
        {
            MainWindow window = new MainWindow();
            window.Show();

            window.setQy(exp);
            Assert.AreEqual(expected, window.getQy());

            window.Close();
        }

        [DataTestMethod]
        [Description("Проверка корректной работы UI для вычисление значения первого полинома P(x)")]
        [DataRow("", 2, 404)]
        [DataRow(" ", 2, 404)]
        [DataRow(".", 2, 404)]
        [DataRow("/", 2, 404)]
        [DataRow("?", 2, 404)]
        [DataRow("$", 2, 404)]
        [DataRow("#", 2, 404)]
        [DataRow("!", 2, 404)]
        [DataRow("arq1ccfashfhas", 2, 404)]
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

            if(expected == 404)
            {
                Assert.AreNotEqual(expected, window.res);
            }
            else
            {
                Assert.AreEqual(expected, window.res);
            }
        }

        [DataTestMethod]
        [Description("Проверка корректной работы UI для вычисление значения первого полинома Q(y)")]
        [DataRow("", 2, 404)]
        [DataRow(" ", 2, 404)]
        [DataRow(".", 2, 404)]
        [DataRow("/", 2, 404)]
        [DataRow("?", 2, 404)]
        [DataRow("$", 2, 404)]
        [DataRow("#", 2, 404)]
        [DataRow("!", 2, 404)]
        [DataRow("arq1ccfashfhas", 2, 404)]
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

            if (expected == 404)
            {
                Assert.AreNotEqual(expected, window.res);
            }
            else
            {
                Assert.AreEqual(expected, window.res);
            }
        }

        [DataTestMethod]
        [Description("Проверка корректной работы UI для вычисление значения P(x)*Q(y)-P(Q(x+y))")]
        [DataRow("", "", 2, 2, 404)]
        [DataRow(" ", "", 2, 2, 404)]
        [DataRow(".", "", 2, 2, 404)]
        [DataRow("/", "", 2, 2, 404)]
        [DataRow("?", "", 2, 2, 404)]
        [DataRow("$", "", 2, 2, 404)]
        [DataRow("#", "", 2, 2, 404)]
        [DataRow("!", "", 2, 2, 404)]
        [DataRow("1", "", 2, 2, 404)]
        [DataRow("", "1", 2, 2, 404)]
        [DataRow("1", "1", 2, 2, 0)]
        [DataRow("x+1", "1", 2, 2, 1)]
        [DataRow("x2+x+1", "1", 2, 2, 4)]
        [DataRow("x2+x+1", "1", -2, 2, 4)]
        [DataRow("x3+x2+x+1", "1", 2, 25, 11)]
        public void CalcSumPolynomTest(string expFirst, string expSecond, int operandFirst, int operandSecond, double expected)
        {
            MainWindow window = new MainWindow();

            window.setPx(expFirst);
            window.setX(operandFirst);
            window.clickPx();
            var firstPolynomRes = window.res;

            window.setQy(expSecond);
            window.setY(operandSecond);
            window.clickQy();
            var secondPolynomRes = window.res;

            window.clickPolySumByXY();
            if (expected == 404)
            {
                Assert.AreNotEqual(expected, window.res);
            }
            else
            {
                Assert.AreEqual(expected, window.res);
            }
        }
    }
}
