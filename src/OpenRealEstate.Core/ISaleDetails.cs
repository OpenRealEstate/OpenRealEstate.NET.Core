namespace OpenRealEstate.Core
{
    public interface ISaleDetails
    {
        string YearBuilt { get; set; }

        string YearLastRenovated { get; set; }

        AuthorityType Authority { get; set; }
    }
}
