using CalculatorUtility.PaymentUtility;

namespace CalculatorUtility.RateUtility
{
    public interface IRateCalculator
    {
        IRateContract GetRateByPayment(IPayment payment, decimal capital, int decimals = 3);
    }
}
