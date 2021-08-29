using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class SchemaNode
    {
        public bool required { get; set; }
        public string format => schema.Format;
        public string dataTypeWithEnum => TemplateHelper.GetDataType(schema.Type);

        public SchemaNode(KeyValuePair<string, OpenApiSchema> schemaNode) : this(schemaNode.Key, schemaNode.Value) { }

        public SchemaNode(string key, OpenApiSchema node)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            baseName = key;
            name = TemplateHelper.PascalCase(key);
            schema = node;
        }
        private List<SchemaNode> _vars;

        public List<SchemaNode> GetVars()
        {
            if(_vars == null)
            {
                _vars = schema.Properties.Select(p => new SchemaNode(p.Key, p.Value)
                {
                    required = schema.Required.Contains(p.Key, StringComparer.OrdinalIgnoreCase),
                    hasMore = true
                }).ToList();

                if(_vars.Any())
                {
                    _vars.Last().hasMore = false;
                }
            }
            return _vars;
        }

        public string baseName { get; private set; }
        public string name { get; }
        public OpenApiSchema schema { get; }
        public string description => schema.Description;
        public bool hasMore { get; private set; }

        public bool isArray => schema.Type.Equals("array", StringComparison.OrdinalIgnoreCase);

        public bool isEnum => schema.Enum.Any();
    }
}
