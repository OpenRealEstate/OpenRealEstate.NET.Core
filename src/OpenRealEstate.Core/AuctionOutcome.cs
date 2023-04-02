using System;

namespace OpenRealEstate.Core
{
    public class AuctionOutcome
    {
        public AuctionResultType Result { get; set; }
        public DateTime AuctionDate { get; set; }
        public decimal MaxBid { get; set; }
    }
}
