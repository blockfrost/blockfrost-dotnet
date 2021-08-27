// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;

namespace Blockfrost.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static BlockfrostProject GetProject(this IConfiguration config, string projectName)
        {
            return config.GetSection($"Blockfrost:{projectName}").Get<BlockfrostProject>();
        }
    }
}
