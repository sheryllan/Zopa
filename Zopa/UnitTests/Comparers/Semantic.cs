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
        public static SemanticComparer<IRateContract, IRateContract> RateComparer => new SemanticComparer<IRateContract, IRateContract>();
        public static SemanticComparer<IPayment, IPayment> PaymentComparer => new SemanticComparer<IPayment, IPayment>();
        public static SemanticComparer<Offer> OfferComparer => new SemanticComparer<Offer>(new MemberComparer(RateComparer));
        public static SemanticComparer<IQuote> QuoteComparer => new SemanticComparer<IQuote>(new MemberComparer(RateComparer), new MemberComparer(PaymentComparer));



    }
}
