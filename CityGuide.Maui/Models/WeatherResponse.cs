using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CityGuide.Maui.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("location")]
        public WeatherLocation Location { get; set; } = new();

        [JsonPropertyName("current_observation")]
        public CurrentObservation CurrentObservation { get; set; } = new();
    }

    public class WeatherLocation
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
    }

    public class CurrentObservation
    {
        [JsonPropertyName("condition")]
        public WeatherCondition Condition { get; set; } = new();

        [JsonPropertyName("atmosphere")]
        public WeatherAtmosphere Atmosphere { get; set; } = new();
    }

    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
    }

    public class WeatherAtmosphere
    {
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}
