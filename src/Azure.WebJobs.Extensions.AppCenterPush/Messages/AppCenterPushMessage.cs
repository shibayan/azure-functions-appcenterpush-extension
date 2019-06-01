using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    [JsonObject]
    public class AppCenterPushMessage
    {
        [JsonProperty("notification_content")]
        public AppCenterPushContent Content { get; set; }

        [JsonProperty("notification_target")]
        public AppCenterPushTarget Target { get; set; }
    }
}
