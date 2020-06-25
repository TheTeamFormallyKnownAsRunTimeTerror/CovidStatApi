using CovidStatApi.Models;
using CovidStatApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CovidStatApi.Extensions
{
    public static class ModelExtensions
    {
        //TODO check automap
        public static LatestStateResponse MapToLatestStateResponse(this CountryData data)
        {
            return new LatestStateResponse()
            {
                ActiveCases = data.ActiveCases,
                ConfirmedCases = data.ConfirmedCases,
                CountryCode = data.CountryCode,
                Deaths = data.Deaths,
                Recovered = data.Recovered
            };
        }
    }
}
