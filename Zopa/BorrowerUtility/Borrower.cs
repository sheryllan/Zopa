using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowerUtility
{
    public abstract class Borrower
    {
        protected readonly int LoanDuration;
        protected readonly int UppderLoanLimit;
        protected readonly int LowerLoanLimit;
        public abstract IQuote GetQuoteWithLowestRate(decimal amount);

        protected Borrower(int duration, int upper, int lower)
        {
            LoanDuration = duration;
            UppderLoanLimit = upper;
            LowerLoanLimit = lower;
        }
    }
}
