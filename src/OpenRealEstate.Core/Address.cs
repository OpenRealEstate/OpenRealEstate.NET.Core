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

        public string SubNumber { get; set; }

        public string LotNumber { get; set; }

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

        /// <summary>
        /// Nice common address template: StreetNumber StreetName, Suburb, State Postcode
        /// </summary>
        /// <example>1/2 Smith Street, Melbourne, Victoria 3000</example>
        /// <remarks>- This will convert any abbreviated 'State' value to it's 'long form'. e.g. VIC => Victoria.<br/>- Use the <code>ToFormattedAddress</code> to customize an address.</remarks>
        /// <returns>A nicely formatted address.</returns>
        public override string ToString()
        {
            return ToFormattedAddress(true, StateReplacementType.ReplaceToLongText, false, true);
        }

        /// <summary>
        /// Generates a nicely formatted address which is nice and human readable.
        /// </summary>
        /// <param name="isStreetAndStreetNumberIncluded">Include the street number and street name? Defaults to: TRUE.</param>
        /// <param name="stateReplacementType">Do we replace the State with any pre-hardcoded values? Defaults to: DON'T REPLACE.</param>
        /// <param name="isCountryCodeIncluded">Do we include the country ISO code? Defaults to: FALSE.</param>
        /// <param name="isPostCodeIncluded">Do we include the postcode? Defaults to: FALSE.</param>
        public string ToFormattedAddress(bool isSubAndLotAndStreetAndStreetNumberIncluded = true,
                                         StateReplacementType stateReplacementType = StateReplacementType.DontReplace,
                                         bool isCountryCodeIncluded = false,
                                         bool isPostCodeIncluded = false)
        {
            var state = string.IsNullOrWhiteSpace(State)
                            ? null
                            : stateReplacementType == StateReplacementType.DontReplace
                                ? State // Don't check or change the current 'State' value.
                                : string.IsNullOrWhiteSpace(State)
                                    ? State // Have nothing to check/change.
                                    : stateReplacementType == StateReplacementType.ReplaceToShortText
                                        ? ToShortStateString(State) // e.g. VIC.
                                        : ToLongStateString(State); // e.g. Victoria.

            return ToFormattedAddress(isSubAndLotAndStreetAndStreetNumberIncluded
                                        ? SubNumber
                                        : null,
                                      isSubAndLotAndStreetAndStreetNumberIncluded
                                        ? LotNumber
                                        : null,
                                      isSubAndLotAndStreetAndStreetNumberIncluded
                                        ? StreetNumber
                                        : null,
                                      isSubAndLotAndStreetAndStreetNumberIncluded
                                        ? Street
                                        : null,
                                      Suburb,
                                      state,
                                      isCountryCodeIncluded
                                        ? CountryIsoCode
                                        : null,
                                      isPostCodeIncluded
                                        ? Postcode
                                        : null);
        }

        /// <summary>
        /// Generates a nicely formatted address which is nice and human readable.
        /// </summary>
        public static string ToFormattedAddress(string subNumber,
                                                string lotNumber,
                                                string streetNumber,
                                                string street,
                                                string suburb,
                                                string state,
                                                string countryIsoCode,
                                                string postcode)
        {
            var result = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(subNumber))
            {
                result.Append(subNumber);
            }

            if (!string.IsNullOrWhiteSpace(lotNumber))
            {
                result.PrependWithDelimeter(lotNumber);
            }

            // Sub-A, LOT 123, 10-A Something Street ..... SUB & LOT & StreetNumber [not expected data - usually no lot with a street number]
            // Sub-A/10-A Something Street .....           SUB & StreetNumber
            // LOT 123, 10-A Something Street .....        LOT & StreetNumber  [not expected data - usually no lot with a street number]
            // LOT 123 Something Street .....              LOT & Street


            // If we have both, then it's a comma-space
            // If we have sub-only, then it's a /
            // If we have lot-only, then it's a comma-space
            var streetNumberPrefix = !string.IsNullOrWhiteSpace(lotNumber)
                ? ", " // both -or- lot-only
                : !string.IsNullOrWhiteSpace(subNumber) && // We have a sub number 
                  int.TryParse(subNumber, out _) // .. and it's a number
                  ? "/" // sub-only and it's a number.
                  : ", "; // sub-only but it's not a number, so we'll use a comma to make it read 'nicer'.

            if (!string.IsNullOrWhiteSpace(streetNumber))
            {
                result.PrependWithDelimeter(streetNumber, streetNumberPrefix);
            }

            if (!string.IsNullOrWhiteSpace(street))
            {
                result.PrependWithDelimeter(street, Space);
            }

            if (!string.IsNullOrWhiteSpace(suburb))
            {
                result.PrependWithDelimeter(suburb);
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                result.PrependWithDelimeter(state);
            }

            if (!string.IsNullOrWhiteSpace(countryIsoCode))
            {
                result.PrependWithDelimeter(countryIsoCode);
            }

            if (!string.IsNullOrWhiteSpace(postcode))
            {
                result.PrependWithDelimeter(postcode, Space);
            }

            return result.ToString();
        }

        public static string ToShortStateString(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentNullException(nameof(state));
            }

            // Check if this key exists.
            // Victoria -> VIC.
            foreach (var group in States)
            {
                if (state.Equals(group[1], StringComparison.OrdinalIgnoreCase))
                {
                    return group[0];
                }
            }

            // Our text might be in an abbreviated way, so lets try again.
            // vic -> VIC.
            foreach (var group in States)
            {
                if (state.Equals(group[0], StringComparison.OrdinalIgnoreCase))
                {
                    return group[0]; // Proper casing for this abbreviated 'State'.
                }
            }

            // Failed to find a match, to just use the original value.
            return state;
        }

        public static string ToLongStateString(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentNullException(nameof(state));
            }

            foreach (var group in States)
            {
                if (state.Equals(group[0], StringComparison.OrdinalIgnoreCase))
                {
                    return group[1];
                }
            }

            return state;
        }
    }
}
