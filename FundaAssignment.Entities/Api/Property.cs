namespace FundaAssignment.Entities.Api
{
    public class Property
    {
        public int MakelaarId { get; set; }

        public string MakelaarNaam { get; set; }

        public string Woonplaats { get; set; }

        public int AntalKamers { get; set; }

        public string Adres { get; set; }

        public PromoLabel PromoLabel { get; set; }
    }
}
