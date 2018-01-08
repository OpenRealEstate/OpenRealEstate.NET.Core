using System;

namespace OpenRealEstate.NET.Core
{
    public abstract class AggregateRoot
    {
        public string Id { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}