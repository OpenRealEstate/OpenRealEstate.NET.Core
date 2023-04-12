namespace OpenRealEstate.Core.Tests.ExtensionTests
{
    public class RearTests : BaseSideTests
    {
        private const string Name = "rear";

        [Fact]
        public void GivenAValidName_Rear_ReturnsAUnitOfMeasure()
        {
            // Arrange, Act & Assert.
            GivenAValidName_Side_ReturnsAUnitOfMeasure(Name);
        }

        [Fact]
        public void GivenAnInvalidName_Rear_ReturnsNull()
        {
            // Arrange, Act & Assert.
            GivenAnInvalidName_Frontage_ReturnsNull(Name);
        }
    }
}
