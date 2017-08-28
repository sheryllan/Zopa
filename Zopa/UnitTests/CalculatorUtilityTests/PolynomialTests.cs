using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.MathUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        public void TestPower()
        {
            Assert.AreEqual(143.48907m, Polynomial.Power(2.7m, 5));
            Assert.AreEqual(216m, Polynomial.Power(6,3));
        }

        [TestMethod]
        public void TestCreate()
        {
            var coefficients = Enumerable.Range(1, 37).Select(x => -30.78m).ToArray();
            coefficients[0] = 1000;
            var func = Polynomial.Create(coefficients);
            Assert.AreEqual(-108.08m, func(1));
        }

        [TestMethod]
        public void TestDerivative()
        {
            var coefficients = new decimal[10];
            coefficients[0] = 10m;
            coefficients[2] = -100.8m;
            coefficients[coefficients.Length - 1] = 70.65m;

            var derivative = Polynomial.Derivative(coefficients);
            Assert.AreEqual(-615.6m, derivative(1m));
        }

        [TestMethod]
        public void TestFactorizeWhenRootIsCorrect()
        {
            var coefficients1 = new decimal[] {2, 9, 5, -6};
            var coefficients2 = new decimal[] {2, 1, -31, -26, 24};

            var expectedC1 = new decimal[] {2, 6, -4};
            var expectedC2 = new decimal[] {2, 9, 5, -6};
            var actualC1 = Polynomial.Factorize(coefficients1, -1.5m);
            var actualC2 = Polynomial.Factorize(coefficients2, 4m);

            CollectionAssert.AreEqual(expectedC1, actualC1);
            CollectionAssert.AreEqual(expectedC2, actualC2);
        }

        [TestMethod]
        public void TestFactorizeWhenRootIsNotCorrect()
        {
            var coefficients1 = new[] {30.7m, -6m, 0m, 0m, 24m, 4.9m};
            var coefficients2 = new[] {1m, -2.6m, -104.4m, 0m};

            var actualC1 = Polynomial.Factorize(coefficients1, 0m);
            var actualC2 = Polynomial.Factorize(coefficients2, 3.5m);

            Assert.IsNull(actualC1);
            Assert.IsNull(actualC2);
        }
    }
}
