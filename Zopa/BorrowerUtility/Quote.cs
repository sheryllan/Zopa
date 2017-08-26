using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrowerUtility
{
    public class Quote
    {
        public int Loan { get; set; }
        public decimal Rate { get; set; }
        public PaymentByMonth Repayment { get; set; }
    }
}
