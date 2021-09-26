using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class ServiceMigrationContext
    {
        private readonly DirectoryInfo _outputDir;
        private readonly OpenApiTag _tag;
        public string GroupName { get; set; }
        public ServiceMigrationContext(DirectoryInfo outputDir, OpenApiTag tag)
        {
            _outputDir = outputDir;
            _tag = tag;

            var serviceName = tag.Name.Split(" ").Last();
            var groupName = tag.Name.Split(" ").First();

            if (groupName.Equals(serviceName))
            {
                groupName = "Common";
            }

            GroupName = groupName;
            NewName = serviceName + "Service";
            OldName = serviceName
                .Replace("sses", "ss")
                .Replace("chs", "ch")
                .Replace("ols", "ol")
                .Replace("ks", "k")
                .Replace("ons", "on")
                .Replace("Accounts", "Account")
                .Replace("ets", "et") + "Service";

            var services = new[] { "HealthService", "MetricsService", "ScriptsService", "AddService", "GatewayService", "PinsService" };
            IsNew = services.Contains(NewName);
        }

        public bool SameName => OldName.Equals(NewName);
        public string OldName { get; set; }
        public bool IsNew { get; }
        public string NewName { get; set; }
    }

    public class BlockfrostServiceExtensionContext : OpenApiContext
    {
        public List<ServiceMigrationContext> Services { get; set; }
        public List<ServiceMigrationContext> Cardano { get; set; }
        public List<ServiceMigrationContext> Common { get; set; }
        public List<ServiceMigrationContext> IPFS { get; set; }
        public List<ServiceMigrationContext> Nutlink { get; set; }
        public List<ServiceMigrationContext> Migrations { get; set; }

        public BlockfrostServiceExtensionContext(DirectoryInfo outputDir, OpenApiDocument spec) : base(spec)
        {
            Services = new List<ServiceMigrationContext>();
            foreach (var tag in Spec.Tags.OrderBy(tag => tag.Name))
            {
                Services.Add(new ServiceMigrationContext(outputDir, tag));
            }
            Migrations = Services.ToList();
            Common = Services.Where(s => s.GroupName.Equals(nameof(Common))).ToList();
            Cardano = Services.Where(s => s.GroupName.Equals(nameof(Cardano))).ToList();
            IPFS = Services.Where(s => s.GroupName.Equals(nameof(IPFS))).ToList();
            Nutlink = Services.Where(s => s.GroupName.Equals(nameof(Nutlink))).ToList();
        }
    }
}
