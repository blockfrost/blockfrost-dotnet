using System.Linq;
using System.Net;
using System.Threading;
using Blockfrost.Api.Tests.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public abstract class AServiceMethodTestBase<TService, TContent> : AServiceTestBase, IServiceMethodTest<TService, TContent>
        where TService : IBlockfrostService
        where TContent : class
    {
        protected AServiceMethodTestBase(string methodName, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            ServiceMethodName = methodName;
        }

        public HttpStatusCode StatusCode { get; }
        public string ServiceMethodName { get; }
        public TService ServiceUnderTest => Provider.GetRequiredService<TService>();
        public abstract TContent Content { get; }
        protected override void OnBuildServiceProvider(IServiceCollection serviceCollection)
        {
            _ = serviceCollection.MockHttpClient(Content, StatusCode);
            base.OnBuildServiceProvider(serviceCollection);
        }

        /// <summary>
        /// Tests the MethodUnderTest. Call <see cref="AssertMethodExists(bool)"/> to simply check if it exists
        /// </summary>
        [TestMethod]
        public abstract void Validate_Service_Method();

        protected void AssertMethodExists(bool assertCancellationSupport = true)
        {
            Assert.IsNotNull(ServiceMethodName);
            if (!assertCancellationSupport)
            {
                return;
            }

            var methods = typeof(TService).GetMethods().Where(m => m.Name.Equals(ServiceMethodName, System.StringComparison.Ordinal));
            var withCancellationSupport = methods.Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(CancellationToken))).ToArray();
            var withoutCancellationSupport = methods.Except(withCancellationSupport).ToArray();
            int withCount = withoutCancellationSupport.Length;
            int withoutCount = withoutCancellationSupport.Length;
            Assert.AreEqual(withCount, withoutCount);
        }
    }
}
