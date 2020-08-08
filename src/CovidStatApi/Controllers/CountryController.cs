using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CovidStatApi.Extensions;
using CovidStatApi.Services;
using CovidStatApi.Services.CountryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovidStatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        
        private CountryService _countryService;
        private ILogger<CountryController> _logger;

        public CountryController(CountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpGet]
        [Route("latest/{countryCode}")]
        public IActionResult GetLatestDataByCountry(string countryCode)
        {
            try
            {
                _logger.LogInformation($"Retrieving latest information for country {countryCode}");
                var countryData = _countryService.GetLatestDataByCountry(countryCode);

                var response = countryData.MapToResponse();

                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while retrieving latest information for {countryCode}: {ex}");
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("countries")]
        public IActionResult GetBasicInfoForAllCountries()
        {
            try
            {
                _logger.LogInformation("Retrieving basic information for all countries");
                var countryInfo = _countryService.GetBasicInfoForAllCountries().Select(ci => ci.MapToResponse());
                return Ok(countryInfo);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception happened while retrieving basic country informaiont: {ex}");
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("historic/{countryCode}")]
        public IActionResult GetHistoricDataByCountry(string countryCode)
        {
            try
            {
                _logger.LogInformation($"Retrieving historic data for country {countryCode}");
                var historicData = _countryService.GetHistoricCountryData(countryCode).Select(cd => cd.MapToHistoricResponse());
                return Ok(historicData);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while retrieving historic country information: {ex}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("base")]
        public IActionResult GetBaseCountryInformation()
        {
            try
            {
                _logger.LogInformation($"Retrieving base country information");
                var listOfCountryData = _countryService.GetBaseCountryInformation();
                var response = listOfCountryData.MapBaseInfoToResponse();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while retrieving base country information: {ex}");
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("combined")]
        public IActionResult GetCombinedCountryInformation()
        {
            try
            {
                
                _logger.LogInformation($"Retrieving combined country information");
                var listOfStaticCountryData = _countryService.GetBaseCountryInformation();
                var listOfCountryData = _countryService.GetBasicInfoForAllCountries();
                var response = CountryDataCombiner.MapCombinedCountryInformation(listOfStaticCountryData, listOfCountryData);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while retrieving base country information: {ex}");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("stats/{countryCode}")]
        public IActionResult GetCountryStatistics(string countryCode)
        {
            try
            {
                _logger.LogInformation($"Retrieving country statistics for country {countryCode}");
                var countryStats = _countryService.GetStatistics(countryCode);

                return Ok(countryStats);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while retrieving country statistic information: {ex}");
                return StatusCode(500);
            }
        }

    }
}
