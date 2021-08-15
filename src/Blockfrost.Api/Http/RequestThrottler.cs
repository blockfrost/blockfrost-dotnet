using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Http
{
    /// <summary>
    /// Middleware for client side request throttling.
    /// Allows a burst of 500 requests, which cools off at rate of 10 requests per second.
    /// If the request limit is reached, the thread waits until new requests are allowed.
    /// No requests are dropped, they are simply delayed.
    /// </summary>
    public class RequestThrottler : DelegatingHandler
    {
        readonly SemaphoreSlim mutex = new SemaphoreSlim(1, 1);
        int requestCount = 0;
        DateTimeOffset lastRequestTime = DateTimeOffset.UtcNow;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await mutex.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var timeSinceLastCall = DateTimeOffset.UtcNow - this.lastRequestTime;
                var cooledOffRequests = timeSinceLastCall.Seconds * Constants.BURST_COOLDOWN;
                this.requestCount = this.requestCount > cooledOffRequests ? this.requestCount - cooledOffRequests : 0;

                while (this.requestCount >= Constants.BURST_LIMIT)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(Constants.BURST_COOLDOWN_INTERVAL), cancellationToken).ConfigureAwait(false);
                    this.requestCount -= Constants.BURST_COOLDOWN;
                }

                this.lastRequestTime = DateTimeOffset.UtcNow;
                this.requestCount++;
            }
            finally
            {
                mutex.Release();
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}

