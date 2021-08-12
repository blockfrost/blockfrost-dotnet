using System.Net.Http;

namespace Blockfrost.Api
{
    public class BasicBlockfrostService : ABlockfrostService, IBlockfrostService
    {
        public BasicBlockfrostService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
