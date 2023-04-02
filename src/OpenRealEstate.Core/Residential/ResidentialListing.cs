using System;

namespace OpenRealEstate.Core.Residential
{
    public class ResidentialListing : Listing, IPropertyType, ISalePricing, IAuctionOn, IBuildingDetails, IAuctionOutcome, ISaleDetails
    {
        public override string ListingType => "Residential";

        public string CouncilRates { get; set; }

        public DateTime? AuctionOn { get; set; }

        public BuildingDetails BuildingDetails { get; set; }

        public PropertyType PropertyType { get; set; }

        public SalePricing Pricing { get; set; }

        public AuctionOutcome AuctionOutcome { get; set; }

        public string YearBuilt { get; set; }

        public string YearLastRenovated { get; set; }

        public AuthorityType Authority { get; set; }

        public override string ToString()
        {
            return $"Residential >> {base.ToString()}";
        }
    }
}
