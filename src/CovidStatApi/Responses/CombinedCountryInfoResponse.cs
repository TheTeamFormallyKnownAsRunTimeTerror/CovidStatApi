using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStatApi.Responses
{
    public class CombinedCountryInfoResponse
    {
        public string CountryName { get; set; }
        public string Iso2 { get; set; }
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
        public int ActiveCases { get; set; }
        public int ConfirmedCases { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
