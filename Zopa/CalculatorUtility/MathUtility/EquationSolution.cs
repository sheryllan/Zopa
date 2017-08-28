using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility.MathUtility
{
    public static class EquationSolution
    {
        private const int MAX_ITER = 100;
        private const decimal MIN_DIVISOR = 10e-7m;
        private const decimal TOLERANCE = 10e-3m;

        public static decimal NewtonMethod(Func<decimal, decimal> func, Func<decimal, decimal> funcPrime, decimal x0, decimal epsilon = TOLERANCE)
        {
            var x1 = x0;
            var found = false;
            for (int i = 0; i < MAX_ITER; i++)
            {
                var fPrime = funcPrime(x0);
                if (Math.Abs(fPrime) < MIN_DIVISOR)
                    break;
                x1 = x0 - func(x0) / fPrime;
                found = Math.Abs(x1 - x0) < epsilon * Math.Abs(x1);
                if (found)
                    break;
                x0 = x1;
            }
            return found ? x1 : decimal.MaxValue;
        }
    }
}
