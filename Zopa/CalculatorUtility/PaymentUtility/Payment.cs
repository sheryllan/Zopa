using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUtility
{
    public class Payment : IPayment
    {
        public int Instalments { get; set; }
        public decimal TotalAmt { get; set; }
    }
}
