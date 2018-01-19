using CalculatorUtility.RateUtility;

namespace CalculatorUtility.PaymentUtility
{
    public interface IPaymentCalculator
    {
        Payment GetPaymentGivenRate(decimal capital, Rate rate, int decimals = 2);
    }
}
