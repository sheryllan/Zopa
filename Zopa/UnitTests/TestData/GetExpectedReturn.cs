using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;

namespace UnitTests.TestData
{
    public class GetExpectedReturn
    {
        public class TestCase
        {
            public Offer Case { get; set; }
            public decimal Result { get; set; }
            public TestCase(Offer c, decimal r)
            {
                Case = c;
                Result = r;
            }
        }

        public static TestCase[] Cases => new[]
        {
            new TestCase(new Offer
            {
                Name = "Bob",
                AvailabeAmt = 640m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.075m,
                    TermsInMonth = 36
                }
            }, 76.69m),
            new TestCase(new Offer
            {
                Name = "Jane",
                AvailabeAmt = 480m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.069m,
                    TermsInMonth = 36
                }
            }, 52.77m),
            new TestCase(new Offer
            {
                Name = "Fred",
                AvailabeAmt = 520m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            }, 58.88m),
            new TestCase(new Offer
            {
                Name = "Mary",
                AvailabeAmt = 170m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.104m,
                    TermsInMonth = 36
                }
            }, 28.63m),
            new TestCase(new Offer
            {
                Name = "John",
                AvailabeAmt = 320m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.081m,
                    TermsInMonth = 36
                }
            }, 41.53m),
            new TestCase(new Offer
            {
                Name = "Dave",
                AvailabeAmt = 140m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.074m,
                    TermsInMonth = 36
                }
            }, 16.54m),
            new TestCase(new Offer
            {
                Name = "Angela",
                AvailabeAmt = 60m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    TermsInMonth = 36
                }
            }, 6.79m),
        };
    }
}
