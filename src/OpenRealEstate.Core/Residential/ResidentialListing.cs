using System;

namespace OpenRealEstate.Core.Residential
{
    public class ResidentialListing : Listing, IPropertyType, ISaleDetails, IBuildingDetails
    {
        public override string ListingType => "Residential";

        public string CouncilRates { get; set; }

        public DateTime? AuctionOn { get; set; }

        public BuildingDetails BuildingDetails { get; set; }

        public PropertyType PropertyType { get; set; }

        public AuthorityType Authority { get; set; }

        public SalePricing Pricing { get; set; }

        public int? YearBuilt { get; set; }

        public int? YearLastRenovated { get; set; }

        public override string ToString()
        {
            return $"Residential >> {base.ToString()}";
        }
    }
}
