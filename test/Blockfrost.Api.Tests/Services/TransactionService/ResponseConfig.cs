// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Net;

namespace Blockfrost.Api.Tests.Services
{
    public class ResponseConfig<TContent>
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public Func<TContent> Content { get; set; }
    }
}
