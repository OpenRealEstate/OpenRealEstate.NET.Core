namespace OpenRealEstate.Core.Tests.Address
{
    public class ToStringTests
    {
        [Fact]
        public void GivenAnAddress_ToString_ReturnsANicelyFormattedAddress()
        {
            // Arrange.
            var expectedformattedAddress = "Sub-A, LOT 123, 10-A Something Street, RICHMOND, Victoria 3121";

            // Act.
            var formattedAddress = FakeData.FakeAddress.ToString();

            // Assert.
            formattedAddress.ShouldBe(expectedformattedAddress);
        }
    }
}
