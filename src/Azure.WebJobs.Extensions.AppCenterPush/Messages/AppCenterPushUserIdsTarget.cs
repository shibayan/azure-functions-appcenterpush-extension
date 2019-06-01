using System.Collections.Generic;

using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushUserIdsTarget : AppCenterPushTarget
    {
        public override string Type => "user_ids_target";

        [JsonProperty("user_ids")]
        public IList<string> UserIds { get; set; } = new List<string>();
    }
}