using System;
using System.Linq;
using CalculatorUtility.PaymentUtility;

namespace CalculatorUtility.RateUtility
{
    // Rate calculator based on monthly payback
    public class RateCalculatorByMonth : IRateCalculator
    {
        //private Func<decimal, decimal> _rateFunc;
        //private decimal[] _coefficients;
        private const int MAX_ITER = 100;

        private const decimal MIN_DIVISOR = 10e-7m;

        // factorization using long divsion
        private decimal[] Factorize(decimal[] coefficients, decimal root)
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

        private decimal Power(decimal x, decimal y)
        {
            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y)));
        }

        private Func<decimal, decimal> BuildPolynomial(decimal[] coefficients)
        {
            var n = coefficients.Length - 1;
            return x => coefficients.Select((c, i) => c * Power(x, n - i)).Sum(f => f);
        }

        private Func<decimal, decimal> PolyDerivative(decimal[] coefficients)
        {
            var n = coefficients.Length - 1;
            return x => coefficients.Select((c, i) => c * (n - i) * Power(x, n - i)).Sum(f => f);
        }

        private decimal NewtonMethod(Func<decimal, decimal> func, Func<decimal, decimal> funcPrime, decimal x0, decimal epsilon)
        {
            var x1 = x0;
            var found = false;
            for (int i = 0; i < MAX_ITER; i++)
            {
                var fPrime = funcPrime(x0);
                if(Math.Abs(fPrime) < MIN_DIVISOR)
                    break;
                x1 = x0 - func(x0) / fPrime;
                found = Math.Abs(x1 - x0) < epsilon * Math.Abs(x1);
                if(found)
                    break;
                x0 = x1;
            }
            return found ? x1 : decimal.MaxValue;
        }
        
        public IRateContract GetRateByPayment(IPayment payment, decimal capital, int decimals = 3)
        {
            var p = new PaymentByMonth()
            {
                Instalments = payment.Instalments,
                TotalAmt = payment.TotalAmt
            };
            var monthly = p.MonthlyAmt;

            var coefficients = new decimal [p.Instalments + 2];
            coefficients[0] = capital;
            coefficients[1] = -monthly - capital;
            coefficients[coefficients.Length - 1] = monthly;

            // Because original rate polynomial function has a root of 1, thus factorizing it to improve the precision of Falsi
            coefficients = Factorize(coefficients, 1);
            if (coefficients == null)
                return null;
           
            // Because rateFunc is monotonically increasing when x > 1, Newton's method converges most quickly and provides best precision
            var rateFunc = BuildPolynomial(coefficients);
            var funcPrime = PolyDerivative(coefficients);
            var epsilon = Power(10, -decimals - 2);
            var rate = NewtonMethod(rateFunc, funcPrime, 1m, epsilon);

            return rate == decimal.MaxValue
                ? null
                : new RateContract()
                {
                    AnnualRate = Math.Round((rate - 1) * 12, decimals),
                    DurationInMonth = p.Instalments
                };
        }
    }
}
