using CovidStatApi.Domain.Domain;
using CovidStatApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

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

       
        //TODO this will need a refactor, does the job for now
        public List<CountryData> GetBasicInfoForAllCountries()
        {
            var countryInfo = from cd in _covidDataContext.CountryData
                              join c in _covidDataContext.Countries on
                              cd.CountryCode equals c.Iso2
                              where c.HasData != null && c.HasData != 0
                              orderby cd.DateTime descending
                              select cd;
                              

            var countryList = countryInfo.ToList();

            return FilterByLatest(countryList);
        }

        private List<CountryData> FilterByLatest(List<CountryData> allData)
        {
            var latest = allData.GroupBy(d => d.CountryCode).Select(g => g.Where(c => c.DateTime == g.Max(c => c.DateTime)).FirstOrDefault());

            return latest.ToList();
        }
    }
}
