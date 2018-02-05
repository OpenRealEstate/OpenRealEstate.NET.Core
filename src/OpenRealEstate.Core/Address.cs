using System;
using System.Text;
using OpenRealEstate.Core.Extensions;

namespace OpenRealEstate.Core
{
    public class Address
    {
        private const string Space = " ";

        // Ordered by population size. Yes - these are only for AU, so far.
        // REF: https://en.wikipedia.org/wiki/Ranked_list_of_states_and_territories_of_Australia
        private static readonly string[][] States =
        {
            new[]
            {
                "NSW",
                "New South Wales"
            },
            new[]
            {
                "VIC",
                "Victoria"
            },
            new[]
            {
                "QLD",
                "Queensland"
            },
            new[]
            {
                "WA",
                "Western Australia"
            },
            new[]
            {
                "SA",
                "South Australia"
            },
            new[]
            {
                "TAS",
                "Tasmania"
            },
            new[]
            {
                "ACT",
                "Australian Capital Territory"
            },
            new[]
            {
                "NT",
                "Northern Territory"
            }
        };

        public string StreetNumber { get; set; }

        public string Street { get; set; }

        public string Suburb { get; set; }

        public string Municipality { get; set; }

        public string State { get; set; }

        /// <remarks>More Info: http://en.wikipedia.org/wiki/ISO_3166-1</remarks>
        public string CountryIsoCode { get; set; }

        public string Postcode { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        /// <summary>
        /// This is the address the agent wants to display to the public. It might not have the street number or appartment numbers or even the suburb!
        /// </summary>
        public string DisplayAddress { get; set; }

        public override string ToString()
        {
            return ToFormattedAddress(true, StateReplacementType.DontReplace, true, true, true);
        }

        /// <summary>
        /// Generates a nicely formatted address which is nice and human readable.
        /// </summary>
        /// <param name="isStreetAndStreetNumberIncluded">Include the street number and street name? Defaults to: TRUE.</param>
        /// <param name="stateReplacementType">Do we replace the State with any pre-hardcoded values? Defaults to: DON'T REPLACE.</param>
        /// <param name="isCountryCodeIncluded">Do we include the country ISO code? Defaults to: FALSE.</param>
        /// <param name="isPostCodeIncluded">Do we include the postcode? Defaults to: FALSE.</param>
        /// <param name="isLatLongIncluded">Do we include some Lat/Long info? Defaults to: FALSE.</param>
        /// <returns></returns>
        public string ToFormattedAddress(bool isStreetAndStreetNumberIncluded = true,
                                         StateReplacementType stateReplacementType = StateReplacementType.DontReplace,
                                         bool isCountryCodeIncluded = false,
                                         bool isPostCodeIncluded = false,
                                         bool isLatLongIncluded = false)
        {
            var address = new StringBuilder();

            // Some agents don't like street numbers and names, for security reasons.
            if (isStreetAndStreetNumberIncluded)
            {
                if (!string.IsNullOrWhiteSpace(StreetNumber))
                {
                    address.Append(StreetNumber);
                }

                if (!string.IsNullOrWhiteSpace(StreetNumber))
                {
                    address.PrependWithDelimeter(Street, Space);
                }
            }

            // Need a bare minimum - which is SUBURB & STATE ...
            if (!string.IsNullOrWhiteSpace(Suburb))
            {
                address.PrependWithDelimeter(Suburb);
            }

            if (!string.IsNullOrWhiteSpace(State))
            {
                var state = stateReplacementType == StateReplacementType.DontReplace
                                ? State
                                : stateReplacementType == StateReplacementType.ReplaceToShortText
                                    ? ToShortStateString()
                                    : ToLongStateString();

                address.PrependWithDelimeter(state);
            }

            // Don't always want to show an ISO Code.
            if (!string.IsNullOrWhiteSpace(CountryIsoCode) &&
                isCountryCodeIncluded)
            {
                address.PrependWithDelimeter(CountryIsoCode);
            }

            if (!string.IsNullOrWhiteSpace(Postcode) &&
                isPostCodeIncluded)
            {
                address.PrependWithDelimeter(Postcode, Space);
            }

            if (isLatLongIncluded)
            {
                address.AppendFormat("; Lat: {0} Long: {1}",
                                     Latitude.HasValue
                                         ? Latitude.Value.ToString("n5")
                                         : "-",
                                     Longitude.HasValue
                                         ? Longitude.Value.ToString("n5")
                                         : "-");
            }

            return address.ToString();
        }

        private string ToShortStateString()
        {
            if (string.IsNullOrWhiteSpace(State))
            {
                return State;
            }

            // Check if this key exists.
            foreach (var group in States)
            {
                if (State.Equals(group[0], StringComparison.OrdinalIgnoreCase))
                {
                    return group[0];
                }
            }

            // Failed to find a match, to just use the original value.
            return State;
        }

        private string ToLongStateString()
        {
            if (string.IsNullOrWhiteSpace(State))
            {
                return State;
            }

            foreach (var group in States)
            {
                if (State.Equals(group[0], StringComparison.OrdinalIgnoreCase))
                {
                    return group[1];
                }
            }

            return State;
        }
    }
}