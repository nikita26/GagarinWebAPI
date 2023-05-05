using System.Text.Json.Serialization;

namespace UseCases
{
    public class OpenMeteoResponse
    {
        [JsonPropertyName("hourly")]
        public Hourly Hourly { get; set; }

        [JsonPropertyName("reason")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("error")]
        public bool IsError { get; set; }
    }

    public class Hourly
    {
        [JsonPropertyName("time")]
        public DateTime[] Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double[] Temperature { get; set;}
    }
}
