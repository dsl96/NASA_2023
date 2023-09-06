using DATA_CLASSES;
using Newtonsoft.Json;

namespace API.services.implementation
{
    public class NasaService : INasaService
    {

        string IMAGE_ENDPOINT = "planetary/apod";
        string API_KEY;


        private readonly HttpClient _client;

        public NasaService(HttpClient client, IConfiguration configuration)
        {

            API_KEY = configuration.GetValue<string>("NASA_KEY")!;

            string NASA_URL = configuration.GetValue<string>("NASA_URL")!;

            client.BaseAddress = new Uri(NASA_URL);

            _client = client;
        }

        public async Task<NasaDailyImageResponse> GetDailyImage(DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                TimeZoneInfo newYorkTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, newYorkTimeZone);
            }

            string date = dateTime.Value.ToString("yyyy-MM-dd");

            var response = await _client.GetAsync(IMAGE_ENDPOINT + $"?api_key={API_KEY}&date={date}");

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<NasaDailyImageResponse>(await response.Content.ReadAsStringAsync())!;
        }
    }
}
