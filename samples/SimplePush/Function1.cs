using System.IO;
using System.Threading.Tasks;

using Azure.WebJobs.Extensions.AppCenterPush;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace SimplePush
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            [AppCenterPush(OwnerName = "shibayan", AppName = "AppCenterPushTest")] IAsyncCollector<AppCenterPushMessage> collector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            var title = data?.title;
            var body = data?.body;

            if (title == null || body == null)
            {
                return new BadRequestResult();
            }

            await collector.AddAsync(new AppCenterPushMessage
            {
                Content = new AppCenterPushContent
                {
                    Name = "pushtest",
                    Title = title,
                    Body = body
                }
            });

            return new OkResult();
        }

        [FunctionName("Function2")]
        [return: AppCenterPush(OwnerName = "shibayan", AppName = "AppCenterPushTest")]
        public static AppCenterPushMessage Send([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            return new AppCenterPushMessage
            {
                Content = new AppCenterPushContent
                {
                    Name = "pushtest",
                    Title = "hoge",
                    Body = "body"
                }
            };
        }
    }
}
