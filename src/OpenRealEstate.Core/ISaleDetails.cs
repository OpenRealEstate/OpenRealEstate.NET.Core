namespace OpenRealEstate.Core
{
    public interface ISaleDetails
    {
        int YearBuilt { get; set; }

        int YearLastRenovated { get; set; }

        AuthorityType Authority { get; set; }
    }
}
