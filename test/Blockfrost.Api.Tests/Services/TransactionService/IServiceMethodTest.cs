// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
