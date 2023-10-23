using System.Text.Json.Serialization;

namespace EventsLogger.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRoles
    {
        worker = 1,
        manager = 2,
        owner = 3,
        admin = 4
    }
}