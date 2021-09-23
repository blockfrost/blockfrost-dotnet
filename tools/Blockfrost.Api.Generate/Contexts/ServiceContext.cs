using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HandlebarsDotNet;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class ServiceContext : OpenApiContext
    {
        public string Version => Spec.Info.Version;

        public Dictionary<KeyValuePair<string, OpenApiPathItem>, Dictionary<OperationType, OpenApiOperation[]>> ops;
        public int test { get; set; } = 1;
        public string ServiceName { get; set; }
        public string GroupName { get; set; }
        public OpenApiTag Tag { get; }
        public bool IsCommon { get; set; }
        public IEnumerable<ServiceOperationContext> Operations => ops.Select(o => new ServiceOperationContext(this, o));

        public ServiceContext(OpenApiDocument spec, OpenApiTag tag) : base(spec)
        {
            ops = Initialize(spec, tag);
            Tag = tag;
            var matches = Regex.Matches(tag.Name, "[a-z0-9]+", RegexOptions.IgnoreCase);
            var serviceName = tag.Name.Split(" ").Last();
            var groupName = tag.Name.Split(" ").First();

            if (groupName.Equals(serviceName))
            {
                IsCommon = true;
                groupName = "Common";
            }
            GroupName = groupName;
            ServiceName = matches[^1].Value;
            DocsLink = new StringBuilder()
                    .Append("https://docs.blockfrost.io")
                    .Append('/').Append("#tag")
                    .Append('/').Append(Tag.Name.Replace(" » ", "-"))
                    .ToString();
        }

        public string DocsLink
        {
            get;set;
        }

        public object first => ops.FirstOrDefault();
        public object last => ops.LastOrDefault();

        private static bool HasTag(KeyValuePair<string, OpenApiPathItem> p, OpenApiTag tag) => p.Value.Operations.Any(o => o.Value.Tags.Contains(tag));

        private static Dictionary<KeyValuePair<string, OpenApiPathItem>, Dictionary<OperationType, OpenApiOperation[]>> Initialize(OpenApiDocument docs, OpenApiTag tag)
        {
            return PathsWithTag(docs, tag).ToDictionary(p => p, p => OperationTypesWhereTag(docs, tag).ToDictionary(k => k, k => FilterOperations(docs, tag, p, k)));
        }

        private static IEnumerable<OperationType> OperationTypesWhereTag(OpenApiDocument docs, OpenApiTag tag)
        {
            return PathsWithTag(docs, tag).SelectMany(p => OperationsWithTag(p, tag)).Select(g => g.Key).Distinct();
        }

        private static IEnumerable<KeyValuePair<string, OpenApiPathItem>> PathsWithTag(OpenApiDocument docs, OpenApiTag tag)
        {
            return docs.Paths.Where(p => HasTag(p, tag));
        }

        private static IEnumerable<KeyValuePair<OperationType, OpenApiOperation>> OperationsWithTag(KeyValuePair<string, OpenApiPathItem> p, OpenApiTag tag)
        {
            return p.Value.Operations.Where(o => o.Value.Tags.Contains(tag));
        }

        private static OpenApiOperation[] FilterOperations(OpenApiDocument docs, OpenApiTag tag, KeyValuePair<string, OpenApiPathItem> p, OperationType k)
        {
            return docs.Paths.Where(p => HasTag(p, tag))
                .SelectMany(p => p.Value.Operations.Where(o => o.Value.Tags.Contains(tag)))
                .Where(o => o.Key == k && p.Value.Operations.Contains(o))
                .Select(o => o.Value).ToArray();
        }
    }
}
