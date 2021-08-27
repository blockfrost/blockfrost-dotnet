using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Services
{
    internal interface IServiceMethodTest<TService, TResult> where TService : IBlockfrostService
    {
        [TestMethod]
        void Validate_Service_Method();
        static IServiceProvider Provider { get; }
        TService ServiceUnderTest { get; }
    }
}
