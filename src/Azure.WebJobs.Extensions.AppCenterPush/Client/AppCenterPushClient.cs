using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushClient
    {
        public AppCenterPushClient(string apiToken, string ownerName, string appName)
        {
            _apiToken = apiToken;
            _ownerName = ownerName;
            _appName = appName;
        }

        private readonly string _apiToken;
        private readonly string _ownerName;
        private readonly string _appName;

        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task NotificationsAsync(AppCenterPushMessage message)
        {
            var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

            content.Headers.TryAddWithoutValidation("X-API-Token", _apiToken);

            await _httpClient.PostAsync($"https://appcenter.ms/api/v0.1/apps/{_ownerName}/{_appName}/push/notifications", content);
        }
    }
}
