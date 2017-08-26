using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorUtility;

namespace LenderUtility
{
    public class Offer : IRate 
    {
        public string Name { get; set; }
        public decimal AvailabeAmt { get; set; }
        public decimal Rate { get; set; }
        public int Duration { get; set; }

        public Offer(string name, decimal available, decimal rate, int duration)
        {
            Name = name;
            AvailabeAmt = available;
            Rate = rate;
            Duration = duration;

        }

        public virtual decimal GetExpectedReturn()
        {
            throw new NotImplementedException();
        }
    }
}
