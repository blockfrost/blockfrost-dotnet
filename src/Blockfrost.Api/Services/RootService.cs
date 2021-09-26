using System.Net.Http;

namespace Blockfrost.Api
{
    public partial class RootService : ABlockfrostService, IBlockfrostService
    {
        public RootService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
