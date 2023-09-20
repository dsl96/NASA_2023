using DATA_CLASSES;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.services.implementation
{
    public class issDataService : IissDataService
    {
        private readonly HttpClient _client;
        private readonly ILogger<issDataService> _logger;  

        private readonly string IssLocationApiEndPoint = "http://api.open-notify.org/iss-now.json";

        private readonly IWorldMapService _worldMapService;

        public issDataService(HttpClient client, IWorldMapService worldMapService, ILogger<issDataService> logger)
        {
            _client = client;
            _worldMapService = worldMapService;
            _logger = logger;  
        }

        public async Task<IssLocationResponse?> GetIssLocation()
        {
            try
            {
                var response = await _client.GetAsync(IssLocationApiEndPoint);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to retrieve ISS location. Status code: {StatusCode}", response.StatusCode);
                    return null;
                }

                //add the lonlat
                var issData = JsonConvert.DeserializeObject<IssLocationResponse>(await response.Content.ReadAsStringAsync())!;

                //add datetime
                issData.dateTime = DateTime.Now;

                //add image bytes (optional null)
                var lonlat = new[] { (issData.iss_position.longitude, issData.iss_position.latitude) };
                issData.imageData = await _worldMapService.GetWorldMap(lonlat);

                if (issData.imageData == null)
                {
                    _logger.LogWarning("Failed to retrieve image data for ISS location.");
                }

                return issData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving ISS location.");
                return null;
            }
        }
    }
}
