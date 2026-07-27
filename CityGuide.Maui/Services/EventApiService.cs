using CityGuide.Maui.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace CityGuide.Maui.Services
{
    public class EventApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string BaseUrl = "https://localhost:44349";

        public async Task<List<SpecialEvent>> GetEvnetsAsync()
        {
            var events = await _httpClient.GetFromJsonAsync<List<SpecialEvent>>($"{BaseUrl}/api/SpecialEvents/GetSpecialEvents");
            return events ?? new List<SpecialEvent>();
        }
    }
}
