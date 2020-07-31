using CovidStatApi.Domain.Domain;
using CovidStatApi.Responses;
using System.Collections.Generic;
using CovidStatApi.Domain.Models;

namespace CovidStatApi.Extensions
{
    public static class ModelExtensions
    {
        //TODO check automap
        public static LatestStateResponse MapToResponse(this CountryData data)
        {
            return new LatestStateResponse()
            {
                ActiveCases = data.ActiveCases,
                ConfirmedCases = data.ConfirmedCases,
                CountryCode = data.CountryCode,
                Date = data.DateTime,
                Deaths = data.Deaths,
                Latitude  = float.Parse(data.Latitude), //TODO
                Longitude = float.Parse(data.Longitude), //TODO
                Recovered = data.Recovered,
                CountryId = data.CountryCode,
                CountryName = data.CountryName,

            };
        }

        public static HistoricDataResponse MapToHistoricResponse(this CountryData data)
        {
            return new HistoricDataResponse()
            {
                Active = data.ActiveCases,
                Confirmed = data.ConfirmedCases,
                CountryCode = data.CountryCode,
                CountryName = data.CountryName,
                Date = data.DateTime,
                Deaths = data.Deaths,
                Recovered = data.Recovered
            };
        }
        
        //TODO
        public static CountryInfoResponse MapToResponse(this CountryInfo info)
        {
            return new CountryInfoResponse()
            {
                CountryId = info.CountryId,
                CountryName = info.CountryName,
                Latitude = float.Parse(info.Latitude),
                Longitude = float.Parse(info.Longitude),
                Active = info.Active
            };
        }

        public static List<BaseCountryInformationResponse> MapBaseInfoToResponse(this List<Countries> listOfCountryData)
        {
            var responseList = new List<BaseCountryInformationResponse>();
            foreach (var country in listOfCountryData)
            {
                var countryToAdd = new BaseCountryInformationResponse()
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
                    HospitalBedsPerThousand = country.HospitalBedsPerThousand
                };

                responseList.Add(countryToAdd);
            }

            return responseList;
        }
    }
}
