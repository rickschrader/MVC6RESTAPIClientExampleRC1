
using Newtonsoft.Json;

namespace MVC6ApiClientExample.Models
{
    public class Album
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }
    }
}
