// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;

namespace Blockfrost.Api.Options
{
    public class BlockfrostOptions : Dictionary<string, BlockfrostProject>
    {
        public int Retries { get; set; } = Constants.RETRIES;
        public int TimeoutMilliseconds { get; set; } = Constants.RETRY_TIMEOUT;
    }
}
