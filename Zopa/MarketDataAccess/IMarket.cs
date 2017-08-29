using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataAccess
{
    public interface IMarket
    {
        MarketType Type { get; set; }
        int TermInMonth { get; set; }
    }
}
