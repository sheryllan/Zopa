namespace CalculatorUtility.PaymentUtility
{
    public interface IPayment
    {
        int Instalments { get; set; }
        decimal TotalAmt { get; set; }
    }
}
