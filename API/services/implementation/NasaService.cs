using API.DAL;
using DATA_CLASSES;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.services.implementation
{
    public class NasaService : INasaService
    {

        string IMAGE_ENDPOINT = "planetary/apod";
        private readonly  string ASTROID_ENDPOINT = "neo/rest/v1/feed";
        string API_KEY;


        private readonly HttpClient _client;
        private readonly IRepository<NasaDailyImageResponse> _dailyImageRepo;
        private readonly ILogger<NasaService> _logger;
        private readonly FireBase _fireBase;
        public NasaService(HttpClient client, IConfiguration configuration, ILogger<NasaService> logger, IRepository<NasaDailyImageResponse> dailyImageRepo)
        {

            API_KEY = configuration.GetValue<string>("NASA_KEY")!;
            string NASA_URL = configuration.GetValue<string>("NASA_URL")!;

            this._dailyImageRepo = dailyImageRepo;

            client.BaseAddress = new Uri(NASA_URL);

            this._client = client;
            this._logger = logger;
            this._fireBase = new FireBase();
        }


        public async Task<NasaDailyImageResponse> GetDailyImage(DateTime? dateTime = null)
        {


            if (dateTime == null)
            {
                TimeZoneInfo newYorkTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, newYorkTimeZone);
            }

            var dateId = NasaDailyImageResponse.ConvertDateTimeToInt(dateTime.Value);

            var dailyImage = await _dailyImageRepo.GetByIdAsync(dateId);

            //if not in db
            if (dailyImage == null)
            {
                dailyImage = await createDailyImage(dateTime.Value);


                if (dailyImage == null)
                {
                    _logger.LogInformation("createDailyImage returned null.");
                    return null!;
                }

                try
                {
                    await _dailyImageRepo.InsertAsync(dailyImage);
                }

                catch (InvalidOperationException ex)
                {
                    //thread1 check
                    //thread2 check
                    //thread1 add
                    //thread2 add -->error
                    return await _dailyImageRepo.GetByIdAsync(dateId);
                }
                catch ( Exception ex)
                {
                  var t = ex.GetType().ToString();
                }
            }

            return dailyImage;
        }
        
        public async Task<AstroidResponse> GetAastroidList(DateTime startDate, DateTime endDate)
        {
            var response = await _client.GetAsync(ASTROID_ENDPOINT + $"?start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}&api_key={API_KEY}");
            if (!response.IsSuccessStatusCode)
                return null!;
            return JsonConvert.DeserializeObject<AstroidResponse>(await response.Content.ReadAsStringAsync())!;
        }

        private async Task<NasaDailyImageResponse> createDailyImage(DateTime dateTime)
        {
            string date = dateTime.ToString("yyyy-MM-dd");

            var response = await _client.GetAsync(IMAGE_ENDPOINT + $"?api_key={API_KEY}&date={date}");

            if (!response.IsSuccessStatusCode)
                return null!;

            return JsonConvert.DeserializeObject<NasaDailyImageResponse>(await response.Content.ReadAsStringAsync())!;
        }


    }
}
