using System;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public static class AppCenterPushWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAppCenterPush(this IWebJobsBuilder builder) => builder.AddAppCenterPush(o => { });

        public static IWebJobsBuilder AddAppCenterPush(this IWebJobsBuilder builder, Action<AppCenterPushOptions> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddExtension<AppCenterPushExtensionConfigProvider>()
                   .BindOptions<AppCenterPushOptions>();

            builder.Services.Configure(configure);

            return builder;
        }
    }
}
