﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GUI.models;
using GUI.MVVM.Model;



namespace GUI.services
{
    internal class NasaClient
    {

        static readonly HttpClient _client;

        private readonly string IMAGE_ENDPOINT = "doron";
        private readonly string ASTROID_LIST_ENDPOINT = "AstroidResponseModel";

        public readonly DateTime MinDate = new DateTime(1995, 1, 1);

        //the max date to get daily image is the date in usa
        public DateTime MaxDate => GetTimeInNewYork();

        static NasaClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5150/Space/");
        }

        public async Task<dailyImageResponse> GetDailyImage(DateTime? dateTime = null)
        {
            string queryUrl = IMAGE_ENDPOINT;

            if (dateTime != null)
            {
                queryUrl = queryUrl + $"?dateTime={dateTime.Value.ToString("yyyy-MM-dd")}";
            }

            var response = await _client.GetAsync(queryUrl);

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<dailyImageResponse>(await response.Content.ReadAsStringAsync());
        }


        public async Task<AstroidResponse> GetAstroidList(DateTime startDate, DateTime endDate)
        {
            var respons = await _client.GetAsync(ASTROID_LIST_ENDPOINT + $@"?startDate={startDate.ToString("yyyy-MM-dd")}&endDate={endDate.ToString("yyyy-MM-dd")}");
            return JsonConvert.DeserializeObject<AstroidResponse>(await respons.Content.ReadAsStringAsync());
        }


        private DateTime GetTimeInNewYork()
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime utcNow = DateTime.UtcNow;
            DateTime newYorkTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);
            return newYorkTime;
        }

    }
}
