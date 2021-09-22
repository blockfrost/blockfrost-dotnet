using System.Collections.Generic;
using System.Linq;
using Blockfrost.Api.Generate.Contexts;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class OpenApiDocumentContext : OpenApiContext
    {
        public OpenApiDocumentContext(System.IO.DirectoryInfo outputDir, OpenApiDocument specs) : base(specs)
        {
            Models = new List<ModelContext>();
            Services = new List<ServiceContext>();
            HttpAttributes = new List<HttpAttributeContext>();
            ServiceExtension = new BlockfrostServiceExtensionContext(outputDir, specs);
            Load();
        }

        public List<ModelContext> Models { get; }
        public List<ServiceContext> Services { get; }
        public List<HttpAttributeContext> HttpAttributes { get; }
        public BlockfrostServiceExtensionContext ServiceExtension { get; }

        public List<ModelContext> LoadModels()
        {
            var models = new List<ModelContext>();
            var successSchemas = Spec.SchemasWhere(r => r.IsSuccessStatusCode());
            var distinctSchemas = successSchemas.Distinct().ToList();

            foreach (var schema in distinctSchemas)
            {
                var model = new ModelContext(Spec, schema);
                models.Add(model);
            }
            return models;
        }

        public void Load()
        {
            Models.Clear();
            Models.AddRange(LoadModels());
            Services.Clear();
            Services.AddRange(LoadServices());
            HttpAttributes.Clear();
            HttpAttributes.AddRange(LoadAttributes());
        }

        private IEnumerable<HttpAttributeContext> LoadAttributes()
        {
            List<KeyValuePair<string, string>> parameters = new()
            {
                new("string", "route"),
                new("string", "version")
            };

            return Spec.Paths.SelectMany(p => p.Value.Operations.Select(m => new HttpAttributeContext(Spec,m.Key,parameters))).ToList();
        }

        private IEnumerable<ServiceContext> LoadServices()
        {
            return (from tag in Spec.Tags select new ServiceContext(Spec, tag)).ToList();
        }
    }
}