using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class SchemaNode
    {
        public bool required { get; set; }
        public object defaultValue { get; set; }
        public string format => schema.Format;
        public string dataTypeWithEnum => TemplateHelper.GetDataType(schema.Type);
        public IEnumerable<SchemaNode> vars => GetVars();
        public string classname => name;
        public string modelName => classname;
        public string itemname => $"{classname}Item";
        public string collectionname => $"{classname}Collection";
        public string description => schema.Description ?? items?.Description;
        public OpenApiSchema items => schema.Items;
        public SchemaNode(KeyValuePair<string, OpenApiSchema> schemaNode) : this(schemaNode.Key, schemaNode.Value) { }

        public bool isEnum => GetIsEnum();
        public bool isNotContainer => schema.OneOf.Any(s => GetIsNotContainer(s)) || GetIsNotContainer(schema);

        private static bool GetIsNotContainer(OpenApiSchema schema) => !string.Equals("string", schema.Type, StringComparison.Ordinal) && !string.Equals("array", schema.Type, StringComparison.Ordinal);

        private static bool GetIsEnum(OpenApiSchema schema)
        {
            if (schema.Type.Equals("integer", StringComparison.OrdinalIgnoreCase)) return true || schema.Enum.Any();
            if (schema.Type.Equals("number", StringComparison.OrdinalIgnoreCase)) return true || schema.Enum.Any();
            if (schema.Type.Equals("string", StringComparison.OrdinalIgnoreCase)) return schema.Enum.Any();
            if (schema.Type.Equals("object", StringComparison.OrdinalIgnoreCase)) return schema.Enum.Any();
            if (schema.Type.Equals("array", StringComparison.OrdinalIgnoreCase)) return schema.Enum.Any();
            return false;
        }
        private bool GetIsEnum()
        {
            if (schema.OneOf.Any())
            {
                return schema.OneOf.Any(s => GetIsEnum(s));
            }
            if (schema.AnyOf.Any())
            {
                return schema.AnyOf.Any(s => GetIsEnum(s));
            }
            return GetIsEnum(schema);
        }

        public SchemaNode(string key, OpenApiSchema node)
        {
            if (key == "/") key = "info";
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
        public SchemaNode(KeyValuePair<string, OpenApiMediaType> node) 
        {
            if (node.Value.Schema == null) 
            {
                baseName = node.Key;
                schema = new OpenApiSchema();
            } 
            else
            {
                baseName = node.Value.Schema.Reference.Id.Split('/').Last();
                schema = node.Value.Schema;
            }

            name = TemplateHelper.PascalCase(baseName);
            
        }
        public SchemaNode(OpenApiMediaType mediaType)
        {
            
        }

        private List<SchemaNode> _vars;

        public List<SchemaNode> GetVars()
        {
            if(_vars == null)
            {
                if (items == null) return null;
                
                _vars = items.Properties.Select(p => new SchemaNode(p.Key, p.Value)
                {
                    required = items.Required.Contains(p.Key, StringComparer.OrdinalIgnoreCase),
                    defaultValue = p.Value.Default == null ? null : new { defaultValue = p.Value.Default },
                    hasMore = true
                }).ToList();

                if(_vars.Any())
                {
                    _vars.Last().hasMore = false;
                }
            }
            return _vars;
        }

        public string GetDataType()
        {
            switch (schema.Type)
            {
                case "string":
                    return "string";
                case "integer":
                    return (bool)(schema?.Format.Equals("int64", StringComparison.OrdinalIgnoreCase)) ? "long" : "int";
                case "number":
                    return "double";
                case "boolean":
                    return "bool";
                case "bool":
                    return "bool";
                default:
                    break;
            }
            return "object";
        }

        public string baseName { get; set; }

        public string name { get; }

        public OpenApiSchema schema { get; }

        public bool hasMore { get; set; }

        public bool isArray => schema.Type.Equals("array", StringComparison.OrdinalIgnoreCase);
    }
}
