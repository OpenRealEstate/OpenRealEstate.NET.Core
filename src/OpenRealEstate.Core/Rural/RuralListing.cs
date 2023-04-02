using System;

namespace OpenRealEstate.Core.Rural
{
    public class RuralListing : Listing, ISalePricing, IAuctionOn, IBuildingDetails, IAuctionOutcome
    {
        public override string ListingType => "Rural";

        public CategoryType CategoryType { get; set; }

        public RuralFeatures RuralFeatures { get; set; }

        public string CouncilRates { get; set; }

        public DateTime? AuctionOn { get; set; }

        public BuildingDetails BuildingDetails { get; set; }

        public SalePricing Pricing { get; set; }

        public AuctionOutcome AuctionOutcome { get; set; }

        public override string ToString()
        {
            return $"Rural >> {base.ToString()}";
        }
    }
}
