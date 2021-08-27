// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

namespace Blockfrost.Api.Options
{
    public class BlockfrostProject
    {
        public string ApiKey { get; set; }
        public string Name { get; set; }
        public string Network { get; set; }
        public string ConnectionLimit { get; set; } = "4";
    }
}
