using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAccess
{
    public class LongTermLoanMarket : IMarket
    {
        public MarketType Type { get; set; }
        public int TermInMonth { get; set; }

        public LongTermLoanMarket(MarketType type, int term)
        {
            Type = type;
            TermInMonth = term;
        }
    }
}
