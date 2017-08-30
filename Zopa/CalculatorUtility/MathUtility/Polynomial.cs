using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility.MathUtility
{
    public static class Polynomial
    {
        public static decimal Power(decimal x, decimal y)
        {
            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y)));
        }
        public static Func<decimal, decimal> Create(decimal[] coefficients)
        {
            var n = coefficients.Length - 1;
            return x => coefficients.Select((c, i) => c * Power(x, n - i)).Sum(f => f);
        }

        public static Func<decimal, decimal> Derivative(decimal[] coefficients)
        {
            var n = coefficients.Length - 1;
            return x => coefficients.Select((c, i) => c * (n - i) * Power(x, n - i)).Sum(f => f);
        }

        public static decimal[] Factorize(decimal[] coefficients, decimal root)
        {
            var result = new decimal[coefficients.Length - 1];
            var product = 0m;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = coefficients[i] + product;
                product = root * result[i];
            }
            return product + coefficients[result.Length] == 0m ? result : null;
        }

    }
}
