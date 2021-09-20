using System.Net.Http;
using System.Threading.Tasks;
using Blockfrost.Api;
using Blockfrost.Api.Services;

namespace Blockfrost.Tools.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var client = HttpClientFactory.Create(new AuthHandler());
            client.BaseAddress = new System.Uri("https://cardano-testnet.blockfrost.io/api/v0/");

            var health = new HealthService(client);
            var transactions = new TransactionsService(client)
            {
                ReadResponseAsString = true
            };

            try
            {
                var infoResponse = await health.GetApiInfoAsync();
                System.Console.WriteLine(infoResponse.ToJson());

                var txResponse = await transactions.GetTxsMetadataCborAsync("3377c1c25d4973f5cf01a16a5ba98131f0f659f90cff39c30f86f10ad1ed2c34");
                System.Console.WriteLine(txResponse.ToJson());
            }
            catch (ApiException ex)
            {
                var data = ex.Data;
                System.Console.WriteLine(data.ToString());
            }
        }
    }
}
