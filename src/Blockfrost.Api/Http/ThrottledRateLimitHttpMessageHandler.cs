using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Http
{
    public class RateHandler : DelegatingHandler
    {
        //private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly object locker = new object();
        private readonly double rate;
        private readonly double per;
        private readonly int maxTries;
        private readonly double sleepSeconds;
        private double allowance;
        private Stopwatch stopwatch;

        public RateHandler(double rate, double per, int maxTries)
        {
            if (rate < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be >= 1");
            }

            this.rate = rate;
            this.per = per;
            allowance = rate;
            this.maxTries = maxTries;
            sleepSeconds = per / rate / 2;
            stopwatch = Stopwatch.StartNew();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            bool allowed = false;
            for (int currentTry = 0; currentTry < maxTries; currentTry++)
            {
                lock (locker)
                {
                    double increase = stopwatch.Elapsed.TotalSeconds * (rate / per);
                    //Logger.Debug($"Time passed={stopwatch.ElapsedMilliseconds}ms Increasing allowance={allowance} to {allowance + increase}");
                    stopwatch = Stopwatch.StartNew();
                    allowance += increase;

                    if (allowance > rate)
                    {
                        //Logger.Debug($"Allowance={allowance} exceeded rate ({rate:F1} / {per:F1})");
                        allowance = rate;
                    }

                    if (allowance >= 1.0)
                    {
                        //Logger.Debug($"Allowance={allowance} >= 1, request allowed, decreasing to {allowance - 1}");
                        allowance--;
                        allowed = true;
                        break;
                    }

                    //Logger.Debug($"Allowance={allowance} < 1.0, delay={sleepSeconds}");
                }

                // not yet, delay then try again
                await Task.Delay(TimeSpan.FromSeconds(sleepSeconds), cancellationToken);
            }

            if (!allowed)
            {
                throw new Exception($"Failed after {maxTries} tries (elapsed = {sw.Elapsed.TotalSeconds:F1}s)");
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

    public class RateLimitHandler : DelegatingHandler 
    {
        private readonly List<DateTimeOffset> _callLog = new List<DateTimeOffset>();
        private readonly List<DateTimeOffset> _acceptLog = new List<DateTimeOffset>();

        static Random _rand = new Random(1815);

        private readonly TimeSpan _limitTime;
        private readonly int _limitCount; 
        private const double _k = 2.0;
        
        public RateLimitHandler() : base()
        {
            _limitCount = Constants.BURST_LIMIT;
            _limitTime = TimeSpan.FromMilliseconds(Constants.BURST_COOLDOWN_INTERVAL);
        }

        public RateLimitHandler(int limitCount, TimeSpan limitTime) : base()
        {
            _limitCount = limitCount;
            _limitTime = limitTime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;

            lock (_callLog)
            {
                /*
                * Beyer et. al. (2018). Site Reliability Engineering. O'Reilly. https://sre.google/sre-book/handling-overload/#eq2101
                */
                double r = _callLog.Count;
                double a = _acceptLog.Count;
                double q = r - (_k * a);
                double crp = q / (r + 1d);
                var p0 = Math.Max(0d, crp);
                var p = _rand.NextDouble();

                // upper limit p0 to give chance of recovery
                if (p < Math.Min(p0, 0.9))
                {
                    throw new InvalidOperationException("This request will not be sent to the server because too many previous requests failed.");
                }

                _callLog.Add(now);

                while (_callLog.Count > _limitCount)
                {
                    _callLog.RemoveAt(0);
                    _acceptLog.Remove(_callLog[0]);
                    _callLog.RemoveAt(0);
                }
            }

           // await LimitDelay(now);


            HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                lock (_acceptLog)
                {
                    _acceptLog.Add(now);
                }
            } 
            else
            {
                var reason = httpResponseMessage.ReasonPhrase;
            }

            return httpResponseMessage;
        }

        private async Task LimitDelay(DateTimeOffset now)
        {
            if (_callLog.Count < _limitCount)
                return;

            var limit = now.Add(-_limitTime);

            var lastCall = DateTimeOffset.MinValue;
            var shouldLock = false;

            lock (_callLog)
            {
                lastCall = _callLog.FirstOrDefault();
                shouldLock = _callLog.Count(x => x >= limit) >= _limitCount;
            }

            var delayTime = shouldLock && (lastCall > DateTimeOffset.MinValue)
                ? (limit - lastCall)
                : TimeSpan.Zero;

            if (delayTime > TimeSpan.Zero)
                await Task.Delay(delayTime);
        }
    }
}

