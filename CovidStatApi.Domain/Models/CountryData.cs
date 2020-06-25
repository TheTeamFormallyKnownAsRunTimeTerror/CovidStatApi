using System;
using System.Collections.Generic;

namespace CovidStatApi.Models
{
    public partial class CountryData
    {
        public int UpdateId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int ConfirmedCases { get; set; }
        public int ActiveCases { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public DateTime DateTime { get; set; }
        public int? CountriesCountryId { get; set; }

        public virtual Countries CountriesCountry { get; set; }
    }
}
