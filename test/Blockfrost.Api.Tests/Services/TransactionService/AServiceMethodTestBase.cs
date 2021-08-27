// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
            if (!assertCancellationSupport)
            {
                return;
            }

            var methods = typeof(TService).GetMethods().Where(m => m.Name.Equals(ServiceMethodName));
            var withCancellationSupport = methods.Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(CancellationToken))).ToArray();
            var withoutCancellationSupport = methods.Except(withCancellationSupport).ToArray();
            int withCount = withoutCancellationSupport.Length;
            int withoutCount = withoutCancellationSupport.Length;
            Assert.AreEqual(withCount, withoutCount);
        }
    }
}
