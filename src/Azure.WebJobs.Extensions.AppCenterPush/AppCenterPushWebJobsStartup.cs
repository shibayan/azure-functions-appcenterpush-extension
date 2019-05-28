using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(Azure.WebJobs.Extensions.AppCenterPush.AppCenterPushWebJobsStartup))]

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAppCenterPush();
        }
    }
}
