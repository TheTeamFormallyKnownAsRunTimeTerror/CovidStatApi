using System.Collections.Generic;

namespace CovidStatApi.Domain.Models
{
    public partial class Countries
    {
        public Countries()
        {
            CountryData = new HashSet<CountryData>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountrySlug { get; set; }
        public string Iso2 { get; set; }
        public byte? HasData { get; set; }

        public virtual ICollection<CountryData> CountryData { get; set; }

        // Enriched Data from OWID

        public double Population { get; set; }
        public double PopulationDensity { get; set; }
        public double MedianAge { get; set; }
        public double Aged65Older { get; set; }
        public double Aged70Older { get; set; }
        public double GdpPerCapita { get; set; }
        public double DiabetesPrevalence { get; set; }
        public double HandwashingFacilities { get; set; }
        public double HospitalBedsPerThousand { get; set; }
        public double LifeExpectancy { get; set; }
    }
}
