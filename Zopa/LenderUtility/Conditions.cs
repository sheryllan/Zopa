using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenderUtility
{
    public class Conditions
    {
        public Predicate<decimal> TotalLoan { get; set; }
        public Predicate<int> DurationInMonth { get; set; }
        public Predicate<Conditions> OverallCondition { get; set; }
    }
}
