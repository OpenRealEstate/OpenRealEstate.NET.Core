using System;

namespace OpenRealEstate.Core
{
    public class SalePricing
    {
        public int SalePrice { get; set; }

        public string SalePriceText { get; set; }

        public bool ShowSalePrice { get; set; }

        public int? SoldPrice { get; set; }

        public string SoldPriceText { get; set; }

        public bool ShowSoldPrice { get; set; }

        public DateTime? SoldOn { get; set; }

        public bool IsUnderOffer { get; set; }

        public override string ToString()
        {
            return
                $"Sale: {SalePrice:C0}/{(string.IsNullOrWhiteSpace(SalePriceText) ? "-no sale price text-" : SalePriceText)} | Sold: {(SoldPrice.HasValue ? SoldPrice.Value.ToString("C0") : "-not sold-")}/{(string.IsNullOrWhiteSpace(SoldPriceText) ? "-no sold price text-" : SoldPriceText)}";
        }
    }
}
