using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CityGuide.Maui.Models
{
    public class ExchangeRateResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("query")]
        public ExchangeQuery Query { get; set; } = new();

        [JsonPropertyName("info")]
        public ExchangeInfo Info { get; set; } = new();

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public double Result { get; set; }
    }

    public class ExchangeQuery
    {
        [JsonPropertyName("from")]
        public string From { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public string To { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class ExchangeInfo
    {
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("rate")]
        public double Rate { get; set; }
    }
}
