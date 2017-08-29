namespace CalculatorUtility.RateUtility
{
    public interface IRateContract
    {
        decimal AnnualRate { get; set; }
        int TermsInMonth { get; set; }
    }
}
