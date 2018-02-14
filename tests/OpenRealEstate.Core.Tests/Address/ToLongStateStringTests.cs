using Shouldly;
using Xunit;

namespace OpenRealEstate.Core.Tests.Address
{
    public class ToLongStateStringTests
    {
        [Theory]
        [InlineData("vic", "Victoria")]
        [InlineData("vIc", "Victoria")]
        [InlineData("Vic", "Victoria")]
        [InlineData("VIC", "Victoria")]
        [InlineData("nsw", "New South Wales")]
        [InlineData("nSw", "New South Wales")]
        [InlineData("qld", "Queensland")]
        [InlineData("wa", "Western Australia")]
        [InlineData("sa", "South Australia")]
        [InlineData("tas", "Tasmania")]
        [InlineData("act", "Australian Capital Territory")]
        [InlineData("nt", "Northern Territory")]
        [InlineData("xxxx", "xxxx")]
        public void GivenAString_ToLongStateString_ReturnsTheLongFormText(string state, string expectedText)
        {
            // Arrange & Act.
            var result = Core.Address.ToLongStateString(state);

            // Assert.
            result.ShouldBe(expectedText);
        }
    }
}
