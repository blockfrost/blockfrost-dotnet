using Blockfrost.Api.Options;
using Microsoft.Extensions.Configuration;

namespace Blockfrost.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static BlockfrostProject GetProject(this IConfiguration config, string projectName)
        {
            if (config is ConfigurationSection section)
            {
                if (section.Path == null)
                {
                    var project = config.GetSection($"Blockfrost:{projectName}").Get<BlockfrostProject>();
                    project.Name = projectName;
                    return project;
                }
            }

            var blockfrostProject = config.GetSection($"{projectName}").Get<BlockfrostProject>();
            blockfrostProject.Name = projectName;
            return blockfrostProject;
        }
    }
}
