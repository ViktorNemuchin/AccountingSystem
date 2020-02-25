using System.Text.Json;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    [JsonConverter(typeof(JsonSerializerOptions))]
    public class ResponseBaseDto
    {
        public string Status { get; set; }
    }
}
