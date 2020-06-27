using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CovidStatApi.Extensions;
using CovidStatApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidStatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //TODO logging
        private CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("latest/{countryCode}")]
        public IActionResult GetLatestDataByCountry(string countryCode)
        {
            try
            {
                var countryData = _countryService.GetLatestDataByCountry(countryCode);

                var response = countryData.MapToResponse();

                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500); //TODO check this
            }
            
        }

        [HttpGet]
        [Route("countries")]
        public IActionResult GetBasicInfoForAllCountries()
        {
            try
            {
                var countryInfo = _countryService.GetBasicInfoForAllCountries().Select(ci => ci.MapToResponse());
                return Ok(countryInfo);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("latest")]
        public IActionResult GetLatestDataForAllCountries()
        {
            return Ok();
        }

        [HttpGet]
        [Route("historic/{countryCode}")]
        public IActionResult GetHistoricDataByCountry(string countryCode)
        {
            return Ok();
        }

    }
}
