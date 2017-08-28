using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.MathUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class EquationSolutionTests
    {
        [TestMethod]
        public void TestNewtonMethodReturnsExpetedUsingProperInitialPoint()
        {
            var func1 = new Func<decimal, decimal>(x => x * x - 2);
            var func2 = new Func<decimal, decimal>(x => Convert.ToDecimal(Math.Sin(Convert.ToDouble(x))));
            var dFunc1 = new Func<decimal, decimal>(x => 2 * x);
            var dFunc2 = new Func<decimal, decimal>(x => Convert.ToDecimal(Math.Cos(Convert.ToDouble(x))));

            Assert.AreEqual(1.41421m, Math.Round(EquationSolution.NewtonMethod(func1, dFunc1, 1m, 10e-5m), 5));
            Assert.AreEqual(3.142m, Math.Round(EquationSolution.NewtonMethod(func2, dFunc2, 2m), 3));
        }

        [TestMethod]
        public void TestNewtonMethodReturnsMaxNumberWhenFunctionNotConverge()
        {
            var func1 = new Func<decimal, decimal>(x => 1 / x);
            var dFunc1 = new Func<decimal, decimal>(x => -1 / x / x);
            Assert.AreEqual(decimal.MaxValue, EquationSolution.NewtonMethod(func1, dFunc1, 1m));
        }

        [TestMethod]
        public void TestNewtonMethodReturnsMaxNumberDueToImproperInitialPoint()
        {
            var func1 = new Func<decimal, decimal>(x => x* x - 2);
            var dFunc1 = new Func<decimal, decimal>(x => 2 * x);
            Assert.AreEqual(decimal.MaxValue, EquationSolution.NewtonMethod(func1, dFunc1, 0m, 10e-5m));
        }

        [TestMethod]
        public void TestNewtonMethodReturnsUnexpectedValueDueToImproperInitialPoint()
        {
            var func1 = new Func<decimal, decimal>(x => Convert.ToDecimal(Math.Sin(Convert.ToDouble(x))));
            var dFunc1 = new Func<decimal, decimal>(x => Convert.ToDecimal(Math.Cos(Convert.ToDouble(x))));
            Assert.AreNotEqual(3.142m, Math.Round(EquationSolution.NewtonMethod(func1, dFunc1, 1.75m), 3));
        }
    }
}
