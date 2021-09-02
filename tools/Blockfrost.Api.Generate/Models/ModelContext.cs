using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class ModelContext
    {
        private OpenApiDocument _doc;
        private readonly OpenApiSchema _schema;
        public OpenApiSchema PropertySchema => _schema;
                
        private string baseName;

        public ModelContext(OpenApiDocument s_doc, KeyValuePair<string, OpenApiSchema> schema)
        {
            _doc = s_doc;
            baseName = schema.Key;
            _schema = schema.Value;
        }

        public ModelContext Item => IsArray ? new ModelContext(_doc, new KeyValuePair<string, OpenApiSchema>(baseName, _schema.Items)) : this;
        public bool HasItem => IsArray && !ReferenceEquals(this, Item);
        public string ItemName => $"{ClassName}Item";
        public string CollectionName => $"{ClassName}Collection";
        public bool IsArray => _schema.Type == "array";
        public bool IsObject => _schema.Type == "object";
        public bool IsEnum => PropertySchema.Enum.Count > 0;
        public IEnumerable<string> Required => PropertySchema.Required;
        
        public List<PropertyContext> Properties
        {
            get
            {
                var properties = PropertySchema.Properties.Select(p => new PropertyContext(this, p)).ToList();
                if (properties.Any()) properties.Last().IsLast = true;
                return properties;
            }
        }

        public bool HasDefaults => Properties.Any(p => p.Default != null);
        public string ClassName => TemplateHelper.PascalCase(baseName);
        public string ReturnType => TemplateHelper.GetReturnType(baseName, PropertySchema);
    }
}