using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HandlebarsDotNet;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{

    public class ServiceContext
    {
        public string Version => Spec.Info.Version;
        public OpenApiDocument Spec { get; private set; }

        public Dictionary<KeyValuePair<string, OpenApiPathItem>, Dictionary<OperationType, OpenApiOperation[]>> ops;
        public int test { get; set; } = 1;
        public string ServiceName { get; set; }
        public string GroupName { get; set; }
        public OpenApiTag Tag { get; }
        public IEnumerable<ServiceOperationContext> Operations => ops.Select(o => new ServiceOperationContext(this, o));
        public ServiceContext(OpenApiDocument docs, OpenApiTag tag)
        {
            Spec = docs;
            ops = Initialize(docs, tag);
            Tag = tag;
            var matches = Regex.Matches(tag.Name, "[a-z]+", RegexOptions.IgnoreCase);
            GroupName = matches[0].Value;
            ServiceName = matches[^1].Value;
        }

        public object first => ops.First();
        public object last => ops.Last();

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
