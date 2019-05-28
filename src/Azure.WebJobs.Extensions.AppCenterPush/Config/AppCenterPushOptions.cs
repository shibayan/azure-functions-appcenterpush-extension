using Microsoft.Azure.WebJobs.Hosting;

using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushOptions : IOptionsFormatter
    {
        public string Format()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }
}
