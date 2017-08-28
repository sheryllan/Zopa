namespace CalculatorUtility.PaymentUtility
{
    public class Payment : IPayment
    {
        public int Instalments { get; set; }
        public decimal TotalAmt { get; set; }
    }
}
