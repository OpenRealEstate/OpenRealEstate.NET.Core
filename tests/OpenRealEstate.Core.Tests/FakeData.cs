namespace OpenRealEstate.Core.Tests
{
    public static class FakeData
    {
        public static Core.Address FakeAddress { get; } = new Core.Address
                                                          {
                                                              SubNumber = "Sub-A",
                                                              LotNumber = "Lot-BCD",
                                                              StreetNumber = "10-A",
                                                              Street = "Something Street",
                                                              Suburb = "RICHMOND",
                                                              Municipality = "Yarra",
                                                              State = "vic",
                                                              Postcode = "3121",
                                                              CountryIsoCode = "AU",
                                                              DisplayAddress = "This is some display address",
                                                              Latitude = 1.1m,
                                                              Longitude = 2.2m
                                                          };
    }
}
