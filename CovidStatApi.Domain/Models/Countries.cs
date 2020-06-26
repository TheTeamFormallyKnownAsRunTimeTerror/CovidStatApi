using System;
using System.Collections.Generic;

namespace CovidStatApi.Models
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
    }
}
