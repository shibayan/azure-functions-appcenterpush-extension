using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public abstract class AppCenterPushTarget
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }
}