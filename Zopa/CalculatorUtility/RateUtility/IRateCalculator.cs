using CalculatorUtility.PaymentUtility;

namespace CalculatorUtility.RateUtility
{
    public interface IRateCalculator
    {
        IRateContract GetRateGivenPayment(IPayment payment, decimal capital, int decimals = 3);
    }
}
