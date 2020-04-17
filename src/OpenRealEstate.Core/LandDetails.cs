using System.Collections.Generic;

namespace OpenRealEstate.Core
{
    public class LandDetails
    {
        public UnitOfMeasure Area { get; set; }

        public IList<Side> Sides { get; set; } = new List<Side>();

        public string CrossOver { get; set; }
    }
}
