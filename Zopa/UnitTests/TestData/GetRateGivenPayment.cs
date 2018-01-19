using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;

namespace UnitTests.TestData
{
    public class GetRateGivenPayment
    {
        public class TestCase
        {
            public decimal Capital { get; set; }
            public Payment Payment { get; set; }
            public Rate Rate { get; set; }

            public TestCase(decimal c, Payment p, Rate r)
            {
                Capital = c;
                Payment = p;
                Rate = r;
            }
        }

        public static TestCase[] Cases => new[]
        {
            new TestCase(1000m, new PaymentByMonth()
            {
                Instalments = 36, TotalAmt = 1111.65m
            }, new RateByMonth
            {
                AnnualRate = 0.070m,
                Months = 36
            }),

            new TestCase(1500m, new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1670.93m
            }, new RateByMonth
            {
                AnnualRate = 0.071m,
                Months = 36
            }),
            
            new TestCase(15000m, new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 16723.06m
            }, new RateByMonth
            {
                AnnualRate = 0.072m,
                Months = 36
            }), 
        };
    }
}
