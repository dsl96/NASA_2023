using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.services.implementation
{
    public class WorldMapService : IWorldMapService
    {
        private readonly string _baseUrl;

        //template param to 'http get' marker param
        private readonly string _markerParam;
        private readonly HttpClient _client;
        private readonly ILogger<WorldMapService> _logger;

        public WorldMapService(HttpClient client, IConfiguration configuration, ILogger<WorldMapService> logger)
        {
            _client = client;
            _logger = logger;

           
            string apiToken = configuration.GetValue<string>("WORLD_MAP_TOKEN")!;
 
            _baseUrl = $@"https://maps.geoapify.com/v1/staticmap?style=klokantech-basic&width=665&height=660&center=lonlat:16.804209,0&zoom=0.3772&color:%23ff0000;size:medium;icon:rocket;icontype:awesome;whitecircle:no&center=lonlat:14.658025,0&apiKey={apiToken}";
            _markerParam = "&marker=lonlat:{0},{1};color:%23ff0000;size:medium;icon:rocket;icontype:awesome;whitecircle:no";
        }

        /// <summary>
        /// get world app image optional markers on the map
        /// </summary>
        /// <param name="markersLonLat"> array of {(longitude, latitude), ... } </param>
        /// <returns> image of world map with markers as byte[]</returns>
        public async Task<byte[]?> GetWorldMap((double, double)[] markersLonLat)
        {

            //add the markers params to the http get url
            string queryMarkerParams = "";

            foreach (var lonlat in markersLonLat)
            {
                //add 'http get' markers param to the url
                queryMarkerParams += string.Format(_markerParam, lonlat.Item1, lonlat.Item2);
            }

            var imageUrlWithParams = _baseUrl + queryMarkerParams;

            return await DownloadImageAsync(imageUrlWithParams);
        }

        /// <summary>
        /// download image from url
        /// </summary>
        /// <param name="imageUrl">url to online image</param>
        /// <returns>image as byte[]</returns>
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
