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
