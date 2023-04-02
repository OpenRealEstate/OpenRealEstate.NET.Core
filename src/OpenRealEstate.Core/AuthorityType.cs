using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRealEstate.Core
{
    public enum AuthorityType
    {
        Unknown,
        Auction,
        Exclusive,
        Multilist,
        Conjunctional,
        Open,
        Sale,
        SetSale,
    }

    public static class AuthorityTypeExtensions
    {
        public static string ToDescription(this AuthorityType value)
        {
            switch (value)
            {
                case AuthorityType.Auction:
                    return "Auction";
                case AuthorityType.Exclusive:
                    return "Exclusive";
                case AuthorityType.Multilist:
                    return "Multilist";
                case AuthorityType.Conjunctional:
                    return "Conjunctional";
                case AuthorityType.Open:
                    return "Open";
                case AuthorityType.Sale:
                    return "Sale";
                case AuthorityType.SetSale:
                    return "SetSale";
                default:
                    return "Unknown";
            }
        }
    }

    public static class AuthorityTypeHelpers
    {
        public static AuthorityType ToAuthorityType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Equals("AUCTION", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.Auction;
            }

            if (value.Equals("EXCLUSIVE", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.Exclusive;
            }

            if (value.Equals("MULTILIST", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.Multilist;
            }

            if (value.Equals("OPEN", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.Open;
            }

            if (value.Equals("SALE", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.Sale;
            }

            if (value.Equals("SETSALE", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("SET SALE", StringComparison.OrdinalIgnoreCase))
            {
                return AuthorityType.SetSale;
            }

            return AuthorityType.Unknown;
        }
    }
}
