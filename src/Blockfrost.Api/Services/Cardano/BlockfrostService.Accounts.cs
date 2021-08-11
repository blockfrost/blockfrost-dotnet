using System.Net.Http;

namespace Blockfrost.Api
{
    public partial class BlockfrostService : ABlockfrostService
    {
        public BlockfrostService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
