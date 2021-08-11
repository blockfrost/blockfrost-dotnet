using Blockfrost.Api.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : ABlockfrostService
    {
        public BlockfrostService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
