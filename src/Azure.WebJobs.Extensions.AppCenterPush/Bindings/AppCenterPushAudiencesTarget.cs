using System.Collections.Generic;

using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushAudiencesTarget : AppCenterPushTarget
    {
        public override string Type => "audiences_target";

        [JsonProperty("audiences")]
        public IList<string> Audiences { get; set; } = new List<string>();
    }
}