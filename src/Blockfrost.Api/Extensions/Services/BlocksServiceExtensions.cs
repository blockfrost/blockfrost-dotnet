using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api.Services.Extensions
{
    public static class BlocksServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Tip</returns>
        public static Task<Models.BlockContentResponse> WaitOne(this IBlocksService service, TimeSpan queryInterval)
        {
            return service.Wait(1, queryInterval);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Tip</returns>
        public static Task<Models.BlockContentResponse> WaitTwo(this IBlocksService service, TimeSpan queryInterval)
        {
            return service.Wait(2, queryInterval);
        }

        public static Task<Models.BlockContentResponse> Wait(this IBlocksService service, int numberOfBlocks, TimeSpan timeout)
        {
            return service.Wait(numberOfBlocks, timeout, null, CancellationToken.None);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Tip</returns>
        public static async Task<Models.BlockContentResponse> Wait(this IBlocksService service, int count, TimeSpan queryInterval, Action<Models.BlockContentResponse> inspectLatest, CancellationToken cancellationToken)
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

                inspectLatest?.Invoke(tip);

                if (count == 0 || cancellationToken.IsCancellationRequested)
                {
                    return tip;
                }

                await Task.Delay(queryInterval, cancellationToken);
            }
        }
    }
}
