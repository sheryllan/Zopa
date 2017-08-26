using CalculatorUtility;

namespace BorrowerUtility
{
    public class PaymentByMonth : IPayment
    {
        public int Instalments { get; set; }
        public decimal TotalAmt { get; set; }

        public decimal MonthlyAmt { get; set; }
    }
}