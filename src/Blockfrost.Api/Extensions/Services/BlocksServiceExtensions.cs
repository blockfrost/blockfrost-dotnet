using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Services.Extensions
{
    public static class BlocksServiceExtensions
    {
        /// <summary>
        /// Gets the current tip and awaits one more block before returning
        /// </summary>
        /// <param name="service">The <see cref="IBlocksService"/></param>
        /// <param name="interval">The interval between queries</param>
        /// <returns>The tip</returns>
        public static Task<Models.BlockContentResponse> WaitOneAsync(this IBlocksService service, TimeSpan interval)
        {
            return service.WaitAsync(1, interval);
        }

        /// <summary>
        /// Gets the current tip and awaits two more blocks before returning
        /// </summary>
        /// <param name="service">The <see cref="IBlocksService"/></param>
        /// <param name="interval">The interval between wueries</param>
        /// <returns>The tip</returns>
        public static Task<Models.BlockContentResponse> WaitTwoAsync(this IBlocksService service, TimeSpan interval)
        {
            return service.WaitAsync(2, interval);
        }

        /// <summary>
        /// Gets the current tip and awaits <paramref name="count"/> more blocks before returning
        /// </summary>
        /// <param name="service">The <see cref="IBlocksService"/></param>
        /// <returns>The tip</returns>
        public static Task<Models.BlockContentResponse> WaitAsync(this IBlocksService service, int count, TimeSpan interval)
        {
            return service.WaitAsync(count, interval, null, CancellationToken.None);
        }

        /// <summary>
        /// Gets the current tip and awaits <paramref name="count"/> more blocks before returning
        /// </summary>
        /// <param name="service">The <see cref="IBlocksService"/></param>
        /// <param name="count">Number of blocks to wait for</param>
        /// <param name="interval">The interval between wueries</param>
        /// <param name="callback">Callback with the current tip</param>
        /// <returns>The tip</returns>
        public static async Task<Models.BlockContentResponse> WaitAsync(this IBlocksService service, int count, TimeSpan interval, Action<Models.BlockContentResponse> callback, CancellationToken cancellationToken)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(count)} must be greater or equal to 0", nameof(count));
            }

            long latestSlot = 0;

            while (true)
            {
                var tip = await service.GetLatestAsync(cancellationToken).ConfigureAwait(false);

                if (latestSlot != tip.Slot)
                {
                    latestSlot = tip.Slot;
                    count--;
                }

                callback?.Invoke(tip);

                if (count == 0 || cancellationToken.IsCancellationRequested)
                {
                    return tip;
                }

                await Task.Delay(interval, cancellationToken);
            }
        }
    }
}
