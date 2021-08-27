// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Net.Http;

namespace Blockfrost.Api
{
    public class RootService : ABlockfrostService, IBlockfrostService
    {
        public RootService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
