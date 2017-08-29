﻿using System;
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
            public IPayment Payment { get; set; }
            public IRateContract Rate { get; set; }

            public TestCase(decimal c, IPayment p, IRateContract r)
            {
                Capital = c;
                Payment = p;
                Rate = r;
            }
        }

        public static TestCase[] Cases => new[]
        {
            new TestCase(1000m, new Payment
            {
                Instalments = 36, TotalAmt = 1111.65m
            }, new RateContract
            {
                AnnualRate = 0.070m,
                TermsInMonth = 36
            }),

            new TestCase(1500m, new Payment
            {
                Instalments = 36,
                TotalAmt = 11670.928438m
            }, new RateContract
            {
                AnnualRate = 0.071m,
                TermsInMonth = 36
            })
        };
    }
}
