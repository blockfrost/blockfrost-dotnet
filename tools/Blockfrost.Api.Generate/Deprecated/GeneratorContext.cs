using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{

    public class GeneratorContext
    {
        public string packageName { get; internal set; }
        public string servicePackage { get; internal set; }
        public string modelPackage { get; internal set; }
        public OpenApiDocument doc { get; }
        public IEnumerable<SchemaContext> components => doc.Components.Schemas.Select(componentSchema => new SchemaContext(this, componentSchema));

        public GeneratorContext(OpenApiDocument document)
        {
            doc = document;
        }

        public GeneratorContext(GeneratorContext context)
        {
            doc = context.doc;
            packageName = context.packageName;
            servicePackage = context.servicePackage;
            modelPackage = context.modelPackage;
        }
    }
}
