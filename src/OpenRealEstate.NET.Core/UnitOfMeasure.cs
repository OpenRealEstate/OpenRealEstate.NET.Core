namespace OpenRealEstate.NET.Core
{
    public class UnitOfMeasure
    {
        public string Type { get; set; }

        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Value} {(string.IsNullOrWhiteSpace(Type) ? "-no type-" : Type)}";
        }
    }
}