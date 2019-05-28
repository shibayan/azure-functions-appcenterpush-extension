using System;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Options;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    [Extension("AppCenterPush", configurationSection: "appCenterPush")]
    public class AppCenterPushExtensionConfigProvider : IExtensionConfigProvider
    {
        public AppCenterPushExtensionConfigProvider(IOptions<AppCenterPushOptions> options, INameResolver nameResolver)
        {
            _options = options.Value;
            _nameResolver = nameResolver;
        }

        private readonly AppCenterPushOptions _options;
        private readonly INameResolver _nameResolver;

        internal const string AppCenterPushApiTokenName = "AppCenterPushApiToken";

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var appCenterPushAttributeRule = context.AddBindingRule<AppCenterPushAttribute>();

            appCenterPushAttributeRule.BindToCollector<AppCenterPushMessage>(typeof(AppCenterPushCollectorBuilder<>), this);
        }

        public AppCenterPushClient GetClient(AppCenterPushAttribute attribute)
        {
            var apiToken = _nameResolver.Resolve(attribute.ApiTokenSetting);

            return new AppCenterPushClient(apiToken, attribute.OwnerName, attribute.AppName);
        }
    }
}
