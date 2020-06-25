using CovidStatApi.Models;
using System;
using System.Linq;

namespace CovidStatApi.Services
{
    public class CountryService
    {
        //dbContext registered as Scoped by default - will be disposed automatically
        private CovidStatsProjectContext _covidDataContext;

        public CountryService(CovidStatsProjectContext covidDataContext)
        {
            _covidDataContext = covidDataContext;
        }

        public CountryData GetLatestDataByCountry(string countryCode)
        {
            var countryData = _covidDataContext.CountryData
                .Where(c => c.CountryCode == countryCode)
                .OrderByDescending(c => c.DateTime)
                .FirstOrDefault();

            return countryData;
        }
    }
}
