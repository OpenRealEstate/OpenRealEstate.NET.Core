namespace OpenRealEstate.Core
{
    public class Depth
    {
        /// <summary>
        /// Which side is this? Left, Right, Front, etc?
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// Depth value in meters.
        /// </summary>
        public decimal Value { get; set; }
    }
}
