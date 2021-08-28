using System.Collections.Generic;

namespace Blockfrost.Api.Options
{
    public class BlockfrostOptions : Dictionary<string, BlockfrostProject>
    {
        public int Retries { get; set; } = Constants.RETRIES;
        public int TimeoutMilliseconds { get; set; } = Constants.RETRY_TIMEOUT;
    }
}
