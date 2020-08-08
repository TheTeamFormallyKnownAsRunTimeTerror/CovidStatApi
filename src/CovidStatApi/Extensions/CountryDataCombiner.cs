using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using CovidStatApi.Domain.Models;
using CovidStatApi.Responses;
using Microsoft.VisualBasic;

namespace CovidStatApi.Extensions
{
    public static class CountryDataCombiner
    {
        public static List<CombinedCountryInfoResponse> MapCombinedCountryInformation(List<Countries> listOfStaticCountryData, List<CountryData> listOfCountryData)
        {
            CountryData covidData;
            var responseList = new List<CombinedCountryInfoResponse>();
            foreach (var country in listOfStaticCountryData)
            {

                covidData = listOfCountryData.FirstOrDefault(x => x.CountryId == country.CountryId);

                //TODO - add stats to combined info potentially
                var countryToAdd = new CombinedCountryInfoResponse()
                {
                    CountryName = country.CountryName,
                    Iso2 = country.Iso2,
                    Population = country.Population,
                    PopulationDensity = country.PopulationDensity,
                    MedianAge = country.MedianAge,
                    Aged65Older = country.Aged65Older,
                    Aged70Older = country.Aged70Older,
                    LifeExpectancy = country.LifeExpectancy,
                    GdpPerCapita = country.GdpPerCapita,
                    DiabetesPrevalence = country.DiabetesPrevalence,
                    HandwashingFacilities = country.HandwashingFacilities,
                    HospitalBedsPerThousand = country.HospitalBedsPerThousand,
                    ActiveCases = covidData.ActiveCases,
                    Deaths = covidData.Deaths,
                    Recovered = covidData.Recovered,
                    ConfirmedCases = covidData.ConfirmedCases,
                };

                responseList.Add(countryToAdd);
            }

            return responseList;
        }
    }
}
