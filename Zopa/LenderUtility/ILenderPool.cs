using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenderUtility
{
    public interface ILenderPool
    {
        List<Offer> AllOffers { get; }
        List<Offer> FindBestOffersForLoan(Predicate<decimal> loan);
    }
}
