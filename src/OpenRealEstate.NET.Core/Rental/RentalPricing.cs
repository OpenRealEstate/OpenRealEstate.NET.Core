using System;

namespace OpenRealEstate.NET.Core.Rental
{
    public class RentalPricing
    {
        public decimal RentalPrice { get; set; }

        public PaymentFrequencyType PaymentFrequencyType { get; set; }

        public string RentalPriceText { get; set; }

        public DateTime? RentedOn { get; set; }

        public decimal? Bond { get; set; }
    }
}