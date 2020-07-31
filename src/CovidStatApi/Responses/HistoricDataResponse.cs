using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStatApi.Responses
{
    public class HistoricDataResponse
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
        public int Active { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
