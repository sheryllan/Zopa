using CalculatorUtility.PaymentUtility;

namespace CalculatorUtility.RateUtility
{
    public interface IRateCalculator
    {
        Rate GetRateGivenPayment(Payment payment, decimal capital, int decimals = 3);
    }
}
