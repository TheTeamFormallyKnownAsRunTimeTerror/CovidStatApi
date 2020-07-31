using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStatApi.Responses
{
    public class LatestStateResponse
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public int ActiveCases { get; set; }
        public int ConfirmedCases { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
        public int Deaths { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Recovered { get; set; }
    }
}
