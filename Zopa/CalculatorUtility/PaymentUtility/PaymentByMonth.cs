using System;

namespace CalculatorUtility
{
    public class PaymentByMonth : IPayment
    {
        public int Instalments { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal MonthlyAmt => Math.Round(TotalAmt / Instalments, 2);
        
    }
}