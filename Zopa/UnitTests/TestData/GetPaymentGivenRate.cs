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
    public class GetPaymentGivenRate
    {
        public class TestCase
        {
            public Offer Case { get; set; }
            public IPayment Result { get; set; }

            public TestCase(Offer c, IPayment r)
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
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 716.69m}),
            new TestCase(new Offer
            {
                Name = "Jane",
                AvailabeAmt = 480m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.069m,
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 532.77m}),
            new TestCase(new Offer
            {
                Name = "Fred",
                AvailabeAmt = 520m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 578.88m}),
            new TestCase(new Offer
            {
                Name = "Mary",
                AvailabeAmt = 170m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.104m,
                    Months = 36
                }
            }, new Payment{Instalments = 36, TotalAmt = 198.63m}),
            new TestCase(new Offer
            {
                Name = "John",
                AvailabeAmt = 320m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.081m,
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 361.53m}),
            new TestCase(new Offer
            {
                Name = "Dave",
                AvailabeAmt = 140m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.074m,
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 156.54m}),
            new TestCase(new Offer
            {
                Name = "Angela",
                AvailabeAmt = 60m,
                RateContract = new RateContract()
                {
                    AnnualRate = 0.071m,
                    Months = 36
                }
            }, new Payment {Instalments = 36, TotalAmt = 66.79m})
        };
    }

}
