using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    [JsonObject]
    public class AppCenterPushContent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("custom_data")]
        public object CustomData { get; set; }
    }
}