namespace CalculatorUtility.RateUtility
{
    public class RateContract : IRateContract
    {
        public decimal AnnualRate { get; set; }
        public int DurationInMonth { get; set; }


    }
}
