namespace OpenRealEstate.Core.Tests.ExtensionTests
{
    public class RightTests : BaseSideTests
    {
        private const string Name = "right";

        [Fact]
        public void GivenAValidName_Right_ReturnsAUnitOfMeasure()
        {
            // Arrange, Act & Assert.
            GivenAValidName_Side_ReturnsAUnitOfMeasure(Name);
        }

        [Fact]
        public void GivenAnInvalidName_Right_ReturnsNull()
        {
            // Arrange, Act & Assert.
            GivenAnInvalidName_Frontage_ReturnsNull(Name);
        }
    }
}
