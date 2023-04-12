using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace OpenRealEstate.Core.Tests.Address
{
    public class ToFormattedAddressTests
    {
        [Theory]
        [InlineData(true, StateReplacementType.DontReplace, true, true, "Sub-A, LOT 123, 10-A Something Street, RICHMOND, vic, AU 3121")] // Full string.
        [InlineData(true, StateReplacementType.DontReplace, true, false, "Sub-A, LOT 123, 10-A Something Street, RICHMOND, vic, AU")] // Full string, no postcode.
        [InlineData(true, StateReplacementType.DontReplace, false, false, "Sub-A, LOT 123, 10-A Something Street, RICHMOND, vic")] // No ISO, no postcode.
        [InlineData(true, StateReplacementType.ReplaceToShortText, false, false, "Sub-A, LOT 123, 10-A Something Street, RICHMOND, VIC")] // Replace vic->VIC, no ISO, no postcode.
        [InlineData(true, StateReplacementType.ReplaceToLongText, false, false, "Sub-A, LOT 123, 10-A Something Street, RICHMOND, Victoria")] // Replace vic->Victoria, no ISO, no postcode.
        [InlineData(false, StateReplacementType.ReplaceToShortText, false, false, "RICHMOND, VIC")] // No street number or street, replace vic->VIC, no ISO, no postcode.
        [InlineData(false, StateReplacementType.DontReplace, false, false, "RICHMOND, vic")] // No street number or street, no ISO, no postcode.
        public void GivenVariousOptions_ToFormattedAddress_ReturnsAFormattedAddress(bool isStreetAndStreetNumberIncluded,
                                                                                    StateReplacementType stateReplacementType,
                                                                                    bool isCountryCodeIncluded,
                                                                                    bool isPostCodeIncluded,
                                                                                    string expectedformattedAddress)
        {
            // Arrange & Act.
            var formattedAddress = FakeData.FakeAddress.ToFormattedAddress(isStreetAndStreetNumberIncluded,
                                                                           stateReplacementType,
                                                                           isCountryCodeIncluded,
                                                                           isPostCodeIncluded);

            // Assert.
            formattedAddress.ShouldBe(expectedformattedAddress);
        }

        public static IEnumerable<object[]> GetAValidAddressGenerator()
        {
            // SUB & LOT & StreetNumber
            // e.g.Sub-A, LOT 123, 10-A Something Street .....
            yield return new object[]
            {
                FakeData.FakeAddress.SubNumber,
                FakeData.FakeAddress.LotNumber,
                FakeData.FakeAddress.StreetNumber,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.SubNumber}, {FakeData.FakeAddress.LotNumber}, {FakeData.FakeAddress.StreetNumber} {FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            // SUB & StreetNumber
            // e.g.Sub-A/10-A Something Street .....
            yield return new object[]
            {
                FakeData.FakeAddress.SubNumber,
                null,
                FakeData.FakeAddress.StreetNumber,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.SubNumber}/{FakeData.FakeAddress.StreetNumber} {FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            // LOT & StreetNumber
            // e.g.LOT 123, 10-A Something Street .....
            yield return new object[]
            {
                null,
                FakeData.FakeAddress.LotNumber,
                FakeData.FakeAddress.StreetNumber,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.LotNumber}, {FakeData.FakeAddress.StreetNumber} {FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            // StreetNumber
            yield return new object[]
            {
                null,
                null,
                FakeData.FakeAddress.StreetNumber,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.StreetNumber} {FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            // LOT & Street Only
            // e.g. LOT 123 Something Street .....
            yield return new object[]
            {
                null,
                FakeData.FakeAddress.LotNumber,
                null,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.LotNumber} {FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            // Street Only
            yield return new object[]
            {
                null,
                null,
                null,
                FakeData.FakeAddress.Street,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.Street}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            yield return new object[]
            {
                null,
                null,
                null,
                null,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            yield return new object[]
            {
                null,
                null,
                null,
                null,
                null,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            yield return new object[]
            {
                null,
                null,
                null,
                null,
                null,
                null,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };

            yield return new object[]
            {
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.Postcode}"
            };

            yield return new object[]
            {
                null,
                null,
                FakeData.FakeAddress.StreetNumber,
                null,
                FakeData.FakeAddress.Suburb,
                FakeData.FakeAddress.State,
                FakeData.FakeAddress.CountryIsoCode,
                FakeData.FakeAddress.Postcode,
                $"{FakeData.FakeAddress.StreetNumber}, {FakeData.FakeAddress.Suburb}, vic, {FakeData.FakeAddress.CountryIsoCode} {FakeData.FakeAddress.Postcode}"
            };
        }

        [Theory]
        [MemberData(nameof(GetAValidAddressGenerator))]
        public void GivenSomeAddressParts_ToFormattedAddress_ReturnsAFormattedAddress(string subNumber,
                                                                                      string lotNumber,
                                                                                      string streetNumber,
                                                                                      string street,
                                                                                      string suburb,
                                                                                      string state,
                                                                                      string countryIsoCode,
                                                                                      string postcode,
                                                                                      string expectedFormattedAddress)
        {
            // Arrange.

            // Act.
            var formattedAddress = Core.Address.ToFormattedAddress(subNumber,
                                                                   lotNumber,
                                                                   streetNumber,
                                                                   street,
                                                                   suburb,
                                                                   state,
                                                                   countryIsoCode,
                                                                   postcode);

            // Arrange.
            formattedAddress.ShouldBe(expectedFormattedAddress);
        }
    }
}
