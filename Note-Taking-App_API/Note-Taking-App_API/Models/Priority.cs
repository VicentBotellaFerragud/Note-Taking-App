using System.Text.Json.Serialization;

namespace Note_Taking_App_API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
}
