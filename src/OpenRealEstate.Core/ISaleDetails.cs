using System;

namespace OpenRealEstate.Core
{
    public interface ISaleDetails
    {
        SalePricing Pricing { get; set; }

        DateTime? AuctionOn { get; set; }

        int YearBuilt { get; set; }

        int YearLastRenovated { get; set; }

        AuthorityType Authority { get; set; }
    }
}
