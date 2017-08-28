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

        public Func<decimal, decimal> BuildPolynomial(decimal[] coefficients)
        {
            var n = coefficients.Length - 1;
            return x => coefficients.Select((c, i) => c * Power(x, n - i)).Sum(f => f);
        }

        // epsilon = half of upper bound for relative error
        private decimal FalsiMethod(Func<decimal, decimal> func, decimal upperBound, decimal lowerBound, decimal epsilon)
        {
            var fupper = func(upperBound);
            var flower = func(lowerBound);

            if(fupper * flower > 0m)
                return decimal.MaxValue;
            if (fupper == 0m || flower == 0m)
                return flower == 0 ? flower : fupper;

            var side = 0;
            const int lowerReplaced = -1;
            const int upperReplaced = 1;
            var zero = (lowerBound * fupper - upperBound * flower) / (fupper - flower);

            while (Math.Abs(upperBound - lowerBound) < epsilon)
            {
                zero = (lowerBound * fupper - upperBound * flower) / (fupper - flower);
                var fzero = func(zero);
                if (fzero == 0m) break;

                lowerBound = fzero * flower > 0m ? zero : lowerBound;
                flower = fzero * flower > 0m ? fzero : flower;
                upperBound = fzero * fupper > 0m ? zero : upperBound;
                fupper = fzero * fupper > 0m ? fzero : fupper;

                switch (side)
                {
                    case lowerReplaced:
                        fupper = lowerBound == zero ? fupper / 2 : fupper;
                        side = lowerReplaced;
                        break;
                    case upperReplaced:
                        flower = upperBound == zero ? flower / 2 : flower;
                        side = upperReplaced;
                        break;
                    default:
                        side = lowerBound == zero ? lowerReplaced : upperReplaced;
                        break;
                }
            }
            return zero;
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

            var rateFunc = BuildPolynomial(coefficients);
            var lowerBound = 1.0m;
            var upperBound = 1.05m;
            var epsilon = Power(10, -decimals - 2);
            var rate = FalsiMethod(rateFunc, upperBound, lowerBound, epsilon);

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
