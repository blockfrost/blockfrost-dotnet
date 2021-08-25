using Blockfrost.Api.Tests.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace Blockfrost.Api.Tests.Services
{
    [TestClass]
    public abstract class AServiceMethodTestBase<TService, TContent> : AServiceTestBase, IServiceMethodTest<TService, TContent> 
        where TService : IBlockfrostService 
        where TContent : class
    {
        public AServiceMethodTestBase(string methodName, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            _statusCode = statusCode;
            ServiceMethodName = methodName;
        }

        private readonly HttpStatusCode _statusCode;
        public HttpStatusCode StatusCode => _statusCode;
        public string ServiceMethodName { get; }
        public TService ServiceUnderTest => Provider.GetRequiredService<TService>();
        public abstract TContent Content { get; }
        protected override void OnBuildServiceProvider(IServiceCollection serviceCollection)
        {
            serviceCollection.MockHttpClient(Content, StatusCode);
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
            if (!assertCancellationSupport) return;

            var methods = typeof(TService).GetMethods().Where(m => m.Name.Equals(ServiceMethodName));
            var withCancellationSupport = methods.Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(CancellationToken))).ToArray();
            var withoutCancellationSupport = methods.Except(withCancellationSupport).ToArray();
            int withCount = withoutCancellationSupport.Count();
            int withoutCount = withoutCancellationSupport.Count();
            Assert.AreEqual(withCount, withoutCount);
        }

        protected TContent CollectionContent(int v) 
        {
            return default(TContent);
        }
    }
}
