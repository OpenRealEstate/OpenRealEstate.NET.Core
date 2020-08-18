using Xunit;

namespace OpenRealEstate.Core.Tests.ExtensionTests
{
    public class FrontageTests : BaseSideTests
    {
        private const string Name = "frontage";

        [Fact]
        public void GivenAValidName_Frontage_ReturnsAUnitOfMeasure()
        {
            // Arrange, Act & Assert.
            GivenAValidName_Side_ReturnsAUnitOfMeasure(Name);
        }

        [Fact]
        public void GivenAnInvalidName_Frontage_ReturnsNull()
        {
            // Arrange, Act & Assert.
            GivenAnInvalidName_Frontage_ReturnsNull(Name);
        }
    }
}
