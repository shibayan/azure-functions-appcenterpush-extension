using System.Collections.Generic;

using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushDevicesTarget : AppCenterPushTarget
    {
        public override string Type => "devices_target";

        [JsonProperty("devices")]
        public IList<string> Devices { get; set; } = new List<string>();
    }
}