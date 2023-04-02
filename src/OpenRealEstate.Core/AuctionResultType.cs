using System;

namespace OpenRealEstate.Core
{
    public enum AuctionResultType
    {
        Unknown,
        SoldPriorToAuction,
        SoldAtAuction,
        PassedIn,
        PassedInVendorBid,
        Withdrawn,
        SoldAfterAuction
    }

    public static class AuctionResultTypeExtensions
    {
        public static string ToDescription(this AuctionResultType value)
        {
            switch (value)
            {
                case AuctionResultType.SoldPriorToAuction:
                    return "Sold Prior To Auction";
                case AuctionResultType.SoldAtAuction:
                    return "Sold At Auction";
                case AuctionResultType.PassedIn:
                    return "Passed In";
                case AuctionResultType.PassedInVendorBid:
                    return "Passed In Vendor Bid";
                case AuctionResultType.Withdrawn:
                    return "Withdrawn";
                case AuctionResultType.SoldAfterAuction:
                    return "Sold After Auction";
                default:
                    return "Unknown";
            }
        }
    }

    public static class AuctionResultTypeHelpers
    {
        public static AuctionResultType ToAuctionResultType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Equals("SOLD-PRIOR-TO-AUCTION", StringComparison.OrdinalIgnoreCase) || 
                value.Equals("SOLDPRIORTOAUCTION", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SOLD PRIOR TO AUCTION", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.SoldPriorToAuction;
            }

            if (value.Equals("SOLD-AT-AUCTION", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SOLDATAUCTION", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SOLD AT AUCTION", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.SoldAtAuction;
            }

            if (value.Equals("PASSED-IN", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("PASSEDIN", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("PASSED IN", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.PassedIn;
            }

            if (value.Equals("PASSED-IN-VENDOR-BID", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("PASSEDINVENDORBID", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("PASSED IN VENDOR BID", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.PassedInVendorBid;
            }

            if (value.Equals("WITHDRAWN", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.Withdrawn;
            }

            if (value.Equals("SOLD-AFTER-AUCTION", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SOLDAFTERAUCTION", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SOLD AFTER AUCTION", StringComparison.OrdinalIgnoreCase))
            {
                return AuctionResultType.SoldAfterAuction;
            }

            return AuctionResultType.Unknown;
        }
    }
}
