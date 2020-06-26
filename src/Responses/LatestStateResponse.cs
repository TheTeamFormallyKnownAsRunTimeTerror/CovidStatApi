using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStatApi.Responses
{
    public class LatestStateResponse
    {
        public int ActiveCases { get; set; }
        public int ConfirmedCases { get; set; }
        public string CountryCode { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
