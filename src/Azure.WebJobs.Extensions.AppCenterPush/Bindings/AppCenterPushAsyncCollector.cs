using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;

namespace Azure.WebJobs.Extensions.AppCenterPush
{
    public class AppCenterPushAsyncCollector<T> : IAsyncCollector<T>
    {
        internal AppCenterPushAsyncCollector(AppCenterPushClient pushClient)
        {
            _pushClient = pushClient;
        }

        private readonly AppCenterPushClient _pushClient;

        public async Task AddAsync(T item, CancellationToken cancellationToken = new CancellationToken())
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (typeof(T) != typeof(AppCenterPushMessage))
            {
                throw new InvalidOperationException("Unsupport binding type.");
            }

            await _pushClient.NotificationsAsync(item as AppCenterPushMessage);
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }
    }
}
