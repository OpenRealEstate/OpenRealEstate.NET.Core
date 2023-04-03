using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRealEstate.Core
{
    public interface ISaleDetails
    {
        string YearBuilt { get; set; }

        string YearLastRenovated { get; set; }

        AuthorityType Authority { get; set; }
    }
}
