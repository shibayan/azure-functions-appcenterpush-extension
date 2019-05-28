using System;

using Microsoft.Azure.WebJobs.Description;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class AppCenterPushAttribute : Attribute
    {
        [AppSetting(Default = AppCenterPushExtensionConfigProvider.AppCenterPushApiTokenName)]
        public string ApiTokenSetting { get; set; }

        [AutoResolve]
        public string OwnerName { get; set; }

        [AutoResolve]
        public string AppName { get; set; }
    }
}
