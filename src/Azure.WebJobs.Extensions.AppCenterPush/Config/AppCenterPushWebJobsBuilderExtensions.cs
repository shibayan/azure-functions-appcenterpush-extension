using System;

using Microsoft.Azure.WebJobs;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public static class AppCenterPushWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAppCenterPush(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<AppCenterPushExtensionConfigProvider>();

            return builder;
        }
    }
}
