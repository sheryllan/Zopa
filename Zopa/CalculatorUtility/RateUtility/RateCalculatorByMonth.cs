using System;
using System.Linq;
using CalculatorUtility.MathUtility;
using CalculatorUtility.PaymentUtility;

namespace CalculatorUtility.RateUtility
{
    // Rate calculator based on monthly payback
    public class RateCalculatorByMonth : IRateCalculator
    {
        private decimal[] SetupRateFuncCoefficients(IPayment payment, decimal capital)
        {
            var p = new PaymentByMonth()
            {
                Instalments = payment.Instalments,
                TotalAmt = payment.TotalAmt
            };
            var monthly = p.MonthlyAmt;

            var coefficients = new decimal[p.Instalments + 2];
            coefficients[0] = capital;
            coefficients[1] = -monthly - capital;
            coefficients[coefficients.Length - 1] = monthly;

            return coefficients;
        }
        public IRateContract GetRateGivenPayment(IPayment payment, decimal capital, int decimals = 3)
        {
            var coefficients = SetupRateFuncCoefficients(payment, capital);

            // Because original rate polynomial function has a root of 1, thus factorizing it to improve the precision of Falsi
            coefficients = Polynomial.Factorize(coefficients, 1);
            if (coefficients == null)
                return null;
           
            // Because rateFunc is monotonically increasing when x > 1, Newton's method converges most quickly and provides best precision
            var rateFunc = Polynomial.Create(coefficients);
            var funcPrime = Polynomial.Derivative(coefficients);
            var epsilon = Polynomial.Power(10, -decimals - 2);
            var rate = EquationSolution.NewtonMethod(rateFunc, funcPrime, 1m, epsilon);

            return rate == decimal.MaxValue
                ? null
                : new RateContract()
                {
                    AnnualRate = Math.Round((rate - 1) * 12, decimals),
                    TermsInMonth = payment.Instalments
                };
        }
    }
}
