using System;

namespace OpenRealEstate.Core.Rental
{
    public class RentalPricing
    {
        public decimal RentalPrice { get; set; }

        public PaymentFrequencyType PaymentFrequencyType { get; set; }

        public string RentalPriceText { get; set; }

        public DateTime? RentedOn { get; set; }

        public decimal? Bond { get; set; }

        public override string ToString()
        {
            return $"Rent: {RentalPrice:C0} {PaymentFrequencyType} | {(string.IsNullOrWhiteSpace(RentalPriceText) ? "-no rent price text-" : RentalPriceText)} | Bond: {Bond:C0}";
        }
    }
}