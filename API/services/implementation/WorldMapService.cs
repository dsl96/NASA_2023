using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.services.implementation
{
    public class WorldMapService : IWorldMapService
    {
        private readonly string _baseUrl;
        private readonly string _markerParam;
        private readonly HttpClient _client;
        private readonly ILogger<WorldMapService> _logger;

        public WorldMapService(HttpClient client, IConfiguration configuration, ILogger<WorldMapService> logger)
        {
            _client = client;
            _logger = logger;

           

            string apiToken = configuration.GetValue<string>("NASA_URL")!;

            var apiKey = "d548c5ed24604be6a9dd0d989631f783";
            _baseUrl = $@"https://maps.geoapify.com/v1/staticmap?style=klokantech-basic&width=665&height=660&center=lonlat:16.804209,0&zoom=0.3772&color:%23ff0000;size:medium;icon:rocket;icontype:awesome;whitecircle:no&center=lonlat:14.658025,0&apiKey={apiKey}";
            _markerParam = "&marker=lonlat:{0},{1};color:%23ff0000;size:medium;icon:rocket;icontype:awesome;whitecircle:no";
        }

        public async Task<byte[]?> GetWorldMap((double, double)[] markersLonLat)
        {
            string queryMarkerParams = "";

            foreach (var lonlat in markersLonLat)
            {
                queryMarkerParams += string.Format(_markerParam, lonlat.Item1, lonlat.Item2);
            }

            var imageUrlWithParams = _baseUrl + queryMarkerParams;

            return await DownloadImageAsync(imageUrlWithParams);
        }


        private async Task<byte[]?> DownloadImageAsync(string imageUrl)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(imageUrl);

                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();
                    return imageBytes;
                }
                else
                {
                    _logger.LogError("Error response dowload world image: {StatusCode}", response.StatusCode);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error downloading world image");
                return null;
            }
        }
    }
}
