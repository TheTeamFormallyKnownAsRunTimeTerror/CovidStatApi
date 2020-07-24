using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStatApi.Responses
{
    public class CountryInfoResponse
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Active { get; set; }
    }
}
