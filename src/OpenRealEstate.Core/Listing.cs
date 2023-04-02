using System;
using System.Collections.Generic;

namespace OpenRealEstate.Core
{
    public abstract class Listing : AggregateRoot
    {
        public abstract string ListingType { get; }

        public string AgencyId { get; set; }

        public StatusType StatusType { get; set; }

        /// <summary>
        /// The original status from the source data.
        /// </summary>
        /// <remarks>Various sources (e.g. REAXml, DomainXml, a custom CSV, etc.) might have their own Statuses. OpenRealEstate then maps their statuses to an OpenRealEstate status.
        ///          During this mapping process, the original value could be lost. Some consumers of this OpenRealEstate instance might require a reference to the original status value
        ///          so this is where the value is stored.</remarks>
        public string SourceStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public IList<Agent> Agents { get; set; } = new List<Agent>();

        public IList<Media> Images { get; set; } = new List<Media>();

        public IList<Media> FloorPlans { get; set; } = new List<Media>();

        public IList<Media> Videos { get; set; } = new List<Media>();

        public IList<Media> Documents { get; set; } = new List<Media>();

        public IList<Inspection> Inspections { get; set; } = new List<Inspection>();

        public LandDetails LandDetails { get; set; }

        public Features Features { get; set; }

        public IList<string> Links { get; set; } = new List<string>();

        public string Authority { get; set; }

        public override string ToString()
        {
            var statusTypeDescription = StatusType.ToDescription();
            var showSourceStatus = true;
            if (!string.IsNullOrWhiteSpace(statusTypeDescription) &&
                !string.IsNullOrWhiteSpace(SourceStatus) &&
                statusTypeDescription.Equals(SourceStatus, StringComparison.OrdinalIgnoreCase))
            {
                showSourceStatus = false;
            }

            return
                $"Agency: {(string.IsNullOrWhiteSpace(AgencyId) ? "--no Agency Id--" : AgencyId)}; Id: {(string.IsNullOrWhiteSpace(Id) ? "--No Id--" : Id)}; {StatusType.ToDescription()}{(showSourceStatus ? string.Format(" [{0}]", SourceStatus) : string.Empty)}";
        }
    }
}
