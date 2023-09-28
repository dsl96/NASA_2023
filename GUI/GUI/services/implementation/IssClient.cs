using GUI.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUI.services.implementation
{
    internal class IssClient : IIssClient
    {

        static readonly HttpClient _client;
        private readonly string ISS_LOCATION_ENDPOINT = "Location";

   
        static IssClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5150/api/Iss/");
        }


        public async Task<IssLocationResponse> GetIssLocation()
        {
            var response = await _client.GetAsync(ISS_LOCATION_ENDPOINT);

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<IssLocationResponse>(await response.Content.ReadAsStringAsync());
        }

    }
}
 
