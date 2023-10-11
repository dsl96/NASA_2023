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

        public async Task<IEnumerable<AstronautResponse>> GetAstronaouts( int take, int skip = 0)
        {

            var url = ASTRONAUTS_ENDPOINT + $"?skip={skip}&take={take}";

            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<IEnumerable<AstronautResponse>>(await response.Content.ReadAsStringAsync());
        }
    }
}
