using Shouldly;
using Xunit;

namespace OpenRealEstate.Core.Tests.Address
{
    public class ToFormattedAddressTests
    {
        private Core.Address FakeAddress { get; } = new Core.Address
                                                    {
                                                        StreetNumber = "10-A",
                                                        Street = "Something Street",
                                                        Suburb = "RICHMOND",
                                                        Municipality = "Yarra",
                                                        State = "vic",
                                                        Postcode = "3121",
                                                        CountryIsoCode = "AU",
                                                        DisplayAddress = "This is some display address",
                                                        Latitude = 1.1m,
                                                        Longitude = 2.2m
                                                    };

        [Theory]
        [InlineData(true, StateReplacementType.DontReplace, true, true, true, "10-A Something Street, RICHMOND, vic, AU 3121; Lat: 1.10000 Long: 2.20000")] // Full string.
        [InlineData(true, StateReplacementType.DontReplace, true, true, false, "10-A Something Street, RICHMOND, vic, AU 3121")] // Full string, no lat/long.
        [InlineData(true, StateReplacementType.DontReplace, true, false, false, "10-A Something Street, RICHMOND, vic, AU")] // Full string, no postcode, no lat/long.
        [InlineData(true, StateReplacementType.DontReplace, false, false, false, "10-A Something Street, RICHMOND, vic")] // No ISO, no postcode, no lat/long.
        [InlineData(true, StateReplacementType.ReplaceToShortText, false, false, false, "10-A Something Street, RICHMOND, VIC")] // Replace vic->VIC, no ISO, no postcode, no lat/long.
        [InlineData(true, StateReplacementType.ReplaceToLongText, false, false, false, "10-A Something Street, RICHMOND, Victoria")] // Replace vic->Victoria, no ISO, no postcode, no lat/long.
        [InlineData(false, StateReplacementType.ReplaceToShortText, false, false, false, "RICHMOND, VIC")] // No street number or street, replace vic->VIC, no ISO, no postcode, no lat/long.
        [InlineData(false, StateReplacementType.DontReplace, false, false, false, "RICHMOND, vic")] // No street number or street, no ISO, no postcode, no lat/long.
        public void GivenVariousOptions_ToFormattedAddress_ReturnsAFormattedAddress(bool isStreetAndStreetNumberIncluded,
                                                                                    StateReplacementType stateReplacementType,
                                                                                    bool isCountryCodeIncluded,
                                                                                    bool isPostCodeIncluded,
                                                                                    bool isLatLongIncluded,
                                                                                    string expectedformattedAddress)
        {
            // Arrange.
            

            // Act.
            var formattedAddress = FakeAddress.ToFormattedAddress(isStreetAndStreetNumberIncluded,
                                                                  stateReplacementType,
                                                                  isCountryCodeIncluded,
                                                                  isPostCodeIncluded,
                                                                  isLatLongIncluded);

            // Assert.
            formattedAddress.ShouldBe(expectedformattedAddress);
        }

        [Fact]
        public void GivenAnAddress_ToString_ReturnsANicelyFormattedAddress()
        {
            // Arrange.

            var expectedformattedAddress = "10-A Something Street, RICHMOND, Victoria 3121";

            // Act.
            var formattedAddress = FakeAddress.ToString();

            // Assert.
            formattedAddress.ShouldBe(expectedformattedAddress);
        }
    }
}