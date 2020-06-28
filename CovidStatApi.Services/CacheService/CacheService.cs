using CovidStatApi.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CovidStatApi.Services.CacheService
{
    public class CacheService : BackgroundService
    {
        IMemoryCache _memCache;
        ILogger _logger;
        IServiceProvider _services;

        public CacheService(IMemoryCache memoryCache, ILogger<CacheService> logger, IServiceProvider services)
        {
            _memCache = memoryCache;
            _logger = logger;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Starting cache initialization");
            await InitializeCache(stoppingToken);
        }

        private async Task InitializeCache(CancellationToken stoppingToken)
        {
            using(var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CovidStatsProjectContext>();
                var countryInfo = from cd in dbContext.CountryData
                                  join c in dbContext.Countries on
                                  cd.CountryCode equals c.Iso2
                                  where c.HasData != null && c.HasData != 0 && cd.CountryCode != "US"
                                  orderby cd.DateTime descending
                                  select cd;


                var countryList = countryInfo.ToList();

                var result = FilterByLatest(countryList);
                _memCache.Set("latestBasicInfo", result, TimeSpan.FromDays(7)); //TODO service will be notified to update cache
            }
        }

        private List<CountryData> FilterByLatest(List<CountryData> allData)
        {
            var latest = allData.GroupBy(d => new { d.Latitude, d.Longitude }).Select(g => g.Where(c => c.DateTime == g.Max(c => c.DateTime)).FirstOrDefault());

            return latest.ToList();
        }
    }
}
