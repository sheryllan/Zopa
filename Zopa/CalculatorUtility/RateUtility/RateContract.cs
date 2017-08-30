namespace CalculatorUtility.RateUtility
{
    public class RateContract : IRateContract
    {
        public decimal AnnualRate { get; set; }
        public int Months { get; set; }

        public RateContract() { }

        public RateContract(IRateContract r)
        {
            AnnualRate = r.AnnualRate;
            Months = r.Months;
        }

    }
}
