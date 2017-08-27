using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    public interface IRateContract
    {
        decimal AnnualRate { get; set; }
        int ContractDuration { get; set; }
    }
}
