using System;

namespace OpenRealEstate.Core
{
    public interface ISaleDetails
    {
        AuthorityType Authority { get; set; }
        
        SalePricing Pricing { get; set; }

        DateTime? AuctionOn { get; set; }

        int? YearBuilt { get; set; }

        int? YearLastRenovated { get; set; }
    }
}
