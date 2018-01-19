using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowerUtility
{
    public interface IBorrower
    {
        int LoanDuration { get; }
        int UpperLoanLimit { get; }
        int LowerLoanLimit { get; }
        Quote GetQuoteWithLowestRate(decimal amount);
    }
}
