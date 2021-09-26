using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class PropertyContext
    {
        public PropertyContext(ModelContext modelContext, KeyValuePair<string, OpenApiSchema> p)
        {
            ModelContext = modelContext;
            PropertyNode = p;
        }

        public string DataTypeWithEnum => TemplateHelper.GetDataType(Schema);
        public string BaseName => PropertyNode.Key;
        public string Name => TemplateHelper.PascalCase(BaseName);
        public OpenApiSchema Schema => PropertyNode.Value;
        public string Format => Schema.Format;

        public bool IsEnum 
            => Schema.Type.Equals("integer", System.StringComparison.OrdinalIgnoreCase) 
            || Schema.Type.Equals("number", System.StringComparison.OrdinalIgnoreCase);

        public string Default => Schema.Default.ToString();
        public string Description => Schema.Description;
        public bool AllowNull => !ModelContext.Required.Contains(BaseName);
        public bool Required => ModelContext.Required.Contains(BaseName) || DataTypeWithEnum.Equals("string");
        public ModelContext ModelContext { get; }
        public KeyValuePair<string, OpenApiSchema> PropertyNode { get; }
        public bool IsLast { get; internal set; }
        public bool IsNotContainer => Schema.Type != null 
            ? !(Schema.Type.Equals("array") || Schema.Type.Equals("object"))
            : !Schema.AnyOf.Any(t => t.Type.Equals("array") || t.Type.Equals("object"));
    }
}