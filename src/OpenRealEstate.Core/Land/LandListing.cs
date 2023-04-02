using System;

namespace OpenRealEstate.Core.Land
{
    public class LandListing : Listing, ISalePricing, IAuctionOn, IAuctionOutcome, ISaleDetails
    {
        public override string ListingType => "Land";

        public CategoryType CategoryType { get; set; }

        public LandEstate Estate { get; set; }

        public string CouncilRates { get; set; }

        public DateTime? AuctionOn { get; set; }

        public SalePricing Pricing { get; set; }

        public AuctionOutcome AuctionOutcome { get; set; }

        public string YearBuilt { get; set; }

        public string YearLastRenovated { get; set; }

        public AuthorityType Authority { get; set; }

        public override string ToString()
        {
            return $"Land >> {base.ToString()}";
        }
    }
}
