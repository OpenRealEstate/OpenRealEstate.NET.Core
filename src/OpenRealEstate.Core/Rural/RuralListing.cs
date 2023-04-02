using System;

namespace OpenRealEstate.Core.Rural
{
    public class RuralListing : Listing, ISalePricing, IAuctionOn, IBuildingDetails, IAuctionOutcome, ISaleDetails
    {
        public override string ListingType => "Rural";

        public CategoryType CategoryType { get; set; }

        public RuralFeatures RuralFeatures { get; set; }

        public string CouncilRates { get; set; }

        public DateTime? AuctionOn { get; set; }

        public BuildingDetails BuildingDetails { get; set; }

        public SalePricing Pricing { get; set; }

        public AuctionOutcome AuctionOutcome { get; set; }

        public string YearBuilt { get; set; }

        public string YearLastRenovated { get; set; }

        public AuthorityType Authority { get; set; }

        public override string ToString()
        {
            return $"Rural >> {base.ToString()}";
        }
    }
}
