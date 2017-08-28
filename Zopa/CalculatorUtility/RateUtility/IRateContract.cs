namespace CalculatorUtility.RateUtility
{
    public interface IRateContract
    {
        decimal AnnualRate { get; set; }
        int DurationInMonth { get; set; }
    }
}
