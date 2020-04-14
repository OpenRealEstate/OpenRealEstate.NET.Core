namespace OpenRealEstate.Core
{
    public class UnitOfMeasure
    {
        /// <summary>
        /// Type of unit of measure. e.g. m / m2 / etc..
        /// </summary>
        public string Type { get; set; }

        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Value} {(string.IsNullOrWhiteSpace(Type) ? "-no type-" : Type)}";
        }
    }
}
