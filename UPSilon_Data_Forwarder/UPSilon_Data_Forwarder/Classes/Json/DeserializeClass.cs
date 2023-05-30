using System.Text.Json.Serialization;

namespace UPSilon_Data_Forwarder.Classes.Json
{
    internal class DeserializeClass
    {
        internal class DatapointsResponse
        {
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("datapoints")]
            public List<Datapoint>? Datapoints { get; set; }
        }
        public class Datapoint
        {
            [JsonPropertyName("date")]
            public DateTime Date { get; set; }

            [JsonPropertyName("involtage")]
            public float InVoltage { get; set; }

            [JsonPropertyName("faultvoltage")]
            public float FaultVoltage { get; set; }

            [JsonPropertyName("outputvoltage")]
            public float OutputVoltage { get; set; }

            [JsonPropertyName("current")]
            public int Current { get; set; }

            [JsonPropertyName("frequency")]
            public float Frequency { get; set; }

            [JsonPropertyName("batteryvoltage")]
            public float BatteryVoltage { get; set; }

            [JsonPropertyName("temperature")]
            public string? Temperature { get; set; }

            [JsonPropertyName("upsbinary")]
            public string? UPSBinary { get; set; }
        }

    }
}
