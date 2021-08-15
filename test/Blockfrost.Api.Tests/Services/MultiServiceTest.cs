using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Blockfrost.Api.Tests.Services
{
    /// <summary>
    /// We might need to reconsider on using handlers and
    /// instead configure the clients inside the 
    /// 
    /// This test illustrates that it doesn't work as expected... 
    /// 
    /// IHttpClientFactory expects Transient Handlers in outgoing request middleware
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#outgoing-request-middleware
    /// 
    /// Loosing the AuthorizationHandler is not an issue
    /// _client.Headers.Add("project_id", _project.ApiKey);
    /// 
    /// But we might have to use Polly for the throttling / retries etc...
    /// 
    /// Further reading: 
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#consumption-patterns
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
    /// 
    /// </summary>
    [TestClass]
    public class MultiServiceTest : AServiceTestBase
    {
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConfigureEnvironment(Constants.PROJECT_NAME_TESTNET);
        }

        [TestMethod]
        public void GetTwoDistinctServices()
        {
            try
            {
                Assert.ThrowsException<InvalidOperationException>(() => Provider.GetRequiredService<ITransactionService>());
                Assert.Fail("The Provider could not get the required service");
            }
            catch (AssertFailedException ex)
            {
                // worked as expected
            }

            try
            {
                // This does not work when registering the Handlers as Singleton
                var addressService = Provider.GetRequiredService<IAddressService>();
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
