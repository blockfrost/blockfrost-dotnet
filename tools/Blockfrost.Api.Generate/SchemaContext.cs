using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{

    public class SchemaContext : GeneratorContext
    {
        public SchemaNode node { get; internal set; }
        public OpenApiSchema schema => node.schema;
        public SchemaContext items => new(this, new SchemaNode(classname, schema.Items));
        public IEnumerable<SchemaNode> vars => node.GetVars();
        public string classname => node.name;
        public string modelName => classname;
        public string itemname => $"{classname}Item";
        public string collectionname => $"{classname}Collection";
        public string description => schema.Description ?? items.description;
        public bool isArray => node.isArray;
        public bool isEnum => node.isEnum;

        public SchemaContext(GeneratorContext context, KeyValuePair<string, OpenApiSchema> schemaNode) : this(context, new SchemaNode(schemaNode))
        {
        }

        public SchemaContext(GeneratorContext context, SchemaNode schemaNode) : base(context)
        {
            node = schemaNode;
        }
    }
}
