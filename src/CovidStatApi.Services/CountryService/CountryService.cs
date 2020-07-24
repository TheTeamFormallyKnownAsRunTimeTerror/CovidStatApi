using System;
using System.Collections.Generic;
using System.Linq;
using CovidStatApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CovidStatApi.Services.CountryService
{
    public class CountryService
    {
        //dbContext registered as Scoped by default - will be disposed automatically
        private CovidStatsProjectContext _covidDataContext;
        private IMemoryCache _cache;

        public CountryService(CovidStatsProjectContext covidDataContext, IMemoryCache cache)
        {
            _covidDataContext = covidDataContext;
            _cache = cache;
        }
        public CountryData GetLatestDataByCountry(string countryCode)
        {
            var countryData = _covidDataContext.CountryData
                .Where(c => c.CountryCode == countryCode)
                .OrderByDescending(c => c.DateTime)
                .FirstOrDefault();

            return countryData;
        }

       
        //TODO this will need a refactor, does the job for now
        public List<CountryData> GetBasicInfoForAllCountries()
        {
            if(_cache.TryGetValue("latestBasicInfo", out List<CountryData> cachedResult ))
            {
                return cachedResult;
            }

            var countryInfo = from cd in _covidDataContext.CountryData
                              join c in _covidDataContext.Countries on
                              cd.CountryCode equals c.Iso2
                              where c.HasData != null && c.HasData != 0 && cd.CountryCode != "US"
                              orderby cd.DateTime descending
                              select cd;
                              

            var countryList = countryInfo.ToList();

            var result = FilterByLatest(countryList);
            _cache.Set("latestBasicInfo", result, TimeSpan.FromDays(1)); //TODO invalidate
            return result;
        }

        public List<Countries> GetBaseCountryInformation()
        {
            var countryData = _covidDataContext.Countries
                .Where(c => c.HasData == 1)
                .OrderByDescending(c => c.CountryName)
                .ToListAsync();

            return countryData.Result;
        }

        public List<CountryData> GetHistoricCountryData(string countryCode) =>
                    _covidDataContext.CountryData.Where(cd => cd.CountryCode == countryCode).ToList();
        

        private List<CountryData> FilterByLatest(List<CountryData> allData)
        {
            var latest = allData.GroupBy(d => new { d.Latitude, d.Longitude }).Select(g => g.Where(c => c.DateTime == g.Max(c => c.DateTime)).FirstOrDefault());

            return latest.ToList();
        }
    }
}
