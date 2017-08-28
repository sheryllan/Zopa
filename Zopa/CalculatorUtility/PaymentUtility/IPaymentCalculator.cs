using CalculatorUtility.RateUtility;

namespace CalculatorUtility.PaymentUtility
{
    public interface IPaymentCalculator
    {
        IPayment GetPaymentGivenRate(decimal capital, IRateContract rate, int decimals = 2);
    }
}
