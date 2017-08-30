namespace CalculatorUtility.RateUtility
{
    public interface IRateContract
    {
        decimal AnnualRate { get; set; }
        int Months { get; set; }
    }
}
