namespace OpenRealEstate.Core
{
    public class Side
    {
        /// <summary>
        /// Which side is this? Left, Right, Front, etc?
        /// </summary>
        public string Name { get; set; }

        public UnitOfMeasure Length { get; set; }
    }
}
