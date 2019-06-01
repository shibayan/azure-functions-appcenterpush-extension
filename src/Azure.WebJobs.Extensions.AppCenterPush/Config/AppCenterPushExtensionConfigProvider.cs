using System;

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    [Extension("AppCenterPush", configurationSection: "appCenterPush")]
    public class AppCenterPushExtensionConfigProvider : IExtensionConfigProvider
    {
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

        internal AppCenterPushClient GetClient(AppCenterPushAttribute attribute)
        {
            return new AppCenterPushClient(attribute.ApiTokenSetting, attribute.OwnerName, attribute.AppName);
        }

        private void ValidateBinding(AppCenterPushAttribute attribute)
        {
            if (string.IsNullOrEmpty(attribute.ApiTokenSetting))
            {
                throw new InvalidOperationException("API Token must be set.");
            }
        }
    }
}
