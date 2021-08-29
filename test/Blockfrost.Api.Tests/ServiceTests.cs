using Blockfrost.Api;
using Blockfrost.Api.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Blockfrost.Api.Tests
{
    [TestClass]
    public class ServiceTests
    {
        IConfiguration configuration;

        [TestInitialize]
        public void SetupTestEnvironment()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower(System.Globalization.CultureInfo.InvariantCulture) == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app

            var builder = new ConfigurationBuilder();
            // tell the builder to look for the appsettings.json file
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //only add secrets in development
            if (isDevelopment)
            {
                builder.AddUserSecrets<ServiceTests>();
            }

            configuration = builder.Build();
        }

        [TestMethod]
        [DataRow("Blockfrost.Net.Sdk-testnet")]
        [DataRow("Blockfrost.Net.Sdk-mainnet")]
        [DataRow("Blockfrost.Net.Sdk-ipfs")]
        public async Task CheckHealth(string projectName)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddBlockfrost(projectName, configuration);
            
            var provider = services.BuildServiceProvider();
            IBlockfrostService service = provider.GetRequiredService<IBlockfrostService>();

            var health = await service.GetHealthAsync();
            Assert.IsTrue(health.IsHealthy);
        }
    }
}
