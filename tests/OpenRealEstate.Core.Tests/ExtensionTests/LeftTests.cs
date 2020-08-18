using Xunit;

namespace OpenRealEstate.Core.Tests.ExtensionTests
{
    public class LeftTests : BaseSideTests
    {
        private const string Name = "left";

        [Fact]
        public void GivenAValidName_Left_ReturnsAUnitOfMeasure()
        {
            // Arrange, Act & Assert.
            GivenAValidName_Side_ReturnsAUnitOfMeasure(Name);
        }

        [Fact]
        public void GivenAnInvalidName_Left_ReturnsNull()
        {
            // Arrange, Act & Assert.
            GivenAnInvalidName_Frontage_ReturnsNull(Name);
        }
    }
}
