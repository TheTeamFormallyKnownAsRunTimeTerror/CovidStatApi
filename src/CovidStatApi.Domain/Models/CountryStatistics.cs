using System;
using System.Collections.Generic;

namespace CovidStatApi.Domain.Models
{
    public partial class CountryStatistics
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string MeasureImportances { get; set; }
        public string GrangerStatistics { get; set; }
        public string CountryCode { get; set; }
    }
}
