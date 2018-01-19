using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowerUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using LenderUtility;
using Ploeh.SemanticComparison;

namespace UnitTests.Comparers
{
    public class Semantic
    {
        public static SemanticComparer<Rate, Rate> RateComparer => new SemanticComparer<Rate, Rate>();
        public static SemanticComparer<Payment, Payment> PaymentComparer => new SemanticComparer<Payment, Payment>();
        public static SemanticComparer<Offer> OfferComparer => new SemanticComparer<Offer>(new MemberComparer(RateComparer));
        public static SemanticComparer<Quote> QuoteComparer => new SemanticComparer<Quote>(new MemberComparer(RateComparer), new MemberComparer(PaymentComparer));



    }
}
