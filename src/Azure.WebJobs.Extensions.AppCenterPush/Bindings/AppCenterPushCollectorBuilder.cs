using Microsoft.Azure.WebJobs;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    internal class AppCenterPushCollectorBuilder<T> : IConverter<AppCenterPushAttribute, IAsyncCollector<T>>
    {
        public AppCenterPushCollectorBuilder(AppCenterPushExtensionConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        private readonly AppCenterPushExtensionConfigProvider _configProvider;

        public IAsyncCollector<T> Convert(AppCenterPushAttribute input)
        {
            return new AppCenterPushAsyncCollector<T>(_configProvider.GetClient(input));
        }
    }
}
