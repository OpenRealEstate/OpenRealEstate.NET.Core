using Shouldly;
using Xunit;

namespace OpenRealEstate.Core.Tests.Address
{
    public class ToShortStateStringTests
    {
        [Theory]
        [InlineData("Victoria", "VIC")]
        [InlineData("victoria", "VIC")]
        [InlineData("ViCtOrIa", "VIC")]
        [InlineData("VICTORIA", "VIC")]
        [InlineData("New South Wales", "NSW")]
        [InlineData("Queensland", "QLD")]
        [InlineData("Western Australia", "WA")]
        [InlineData("South Australia", "SA")]
        [InlineData("Tasmania", "TAS")]
        [InlineData("Australian Capital Territory", "ACT")]
        [InlineData("Northern Territory", "NT")]
        [InlineData("xxxx", "xxxx")]
        public void GivenAString_ToShortStateString_ReturnsTheShortFormText(string state, string expectedText)
        {
            // Arrange & Act.
            var result = Core.Address.ToShortStateString(state);

            // Assert.
            result.ShouldBe(expectedText);
        }
    }
}
