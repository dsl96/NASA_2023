using GUI.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUI.services.implementation
{
    internal class AstronautsClient : IAstronautsClient
    {



        static readonly HttpClient _client;
        private readonly string ASTRONAUTS_ENDPOINT = "Astronauts\\getList";


        static AstronautsClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5150/api/");
        }

        public async Task<IEnumerable<AstronautResponse>> GetAstronaouts(AstronautFilter filter)
        {

            var url = ASTRONAUTS_ENDPOINT + BuildQueryString(filter);

            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<IEnumerable<AstronautResponse>>(await response.Content.ReadAsStringAsync());
        }

        string BuildQueryString(AstronautFilter astronautFilter)
        {
            var queryString = $"?Skip={astronautFilter.Skip}&Take={astronautFilter.Take}";

            queryString += $"&IsInSpace={astronautFilter.IsInSpace}";

            queryString += $"&IsAlive={astronautFilter.IsAlive}";
            queryString += $"&Reverse={astronautFilter.Reverse}";

            if (astronautFilter.MinBirthDate.HasValue)
                queryString += $"&MinBirthDate={astronautFilter.MinBirthDate:yyyy- MM -dd}";

            if (astronautFilter.MaxBirthDate.HasValue)
                queryString += $"&MaxBirthDate={astronautFilter.MaxBirthDate:yyyy- MM -dd}";


            if (!string.IsNullOrEmpty(astronautFilter.AgencyAbbrev))
                queryString += $"&AgencyAbbrev={astronautFilter.AgencyAbbrev}";

            if (astronautFilter.MinSpaceWalk.HasValue)
                queryString += $"&MinSpaceWalk={astronautFilter.MinSpaceWalk}";

            if (astronautFilter.MinFlights.HasValue)
                queryString += $"&MinFlights={astronautFilter.MinFlights}";

            if (!string.IsNullOrEmpty(astronautFilter.OrderBy))
                queryString += $"&OrderBy={astronautFilter.OrderBy}";

            return queryString;
        }
    }
}
