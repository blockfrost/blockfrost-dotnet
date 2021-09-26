using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class ParameterContext
    {
        private KeyValuePair<string, string> _context;

        public ParameterContext(OpenApiParameter parameter) : this(
            new KeyValuePair<string, string>(TemplateHelper.GetDataType(parameter.Schema), parameter.Name))
        {
            Parameter = parameter;
            Description = parameter.Description;
            if (IsEnum)
            {
                Type = $"E{TemplateHelper.PascalCase(Name)}";
                if (Name.Equals("Order", System.StringComparison.OrdinalIgnoreCase))
                {
                    Type = "ESortOrder";
                }
            }
            
            if (HasDefault)
            {
                DefaultValue = Parameter.Schema.Default.GetType().GetProperty("Value").GetValue(Parameter.Schema.Default).ToString();
                if(IsEnum)
                {
                    DefaultValue = $"{Type}.{TemplateHelper.PascalCase(DefaultValue)}";
                }
            }

            Optional = !Type.Equals("string", System.StringComparison.OrdinalIgnoreCase) && !Parameter.Required;
        }

        public ParameterContext(KeyValuePair<string, string> kvp)
        {
            _context = kvp;        
            Type = _context.Key.Equals("long") ? "int" : _context.Key;
            Name = _context.Value;
        }

        public bool HasDefault
        {
            get
            {
                return Parameter != null
                       && Parameter.Schema.Default != null
                       && Parameter.Schema.Default.AnyType != Microsoft.OpenApi.Any.AnyType.Null;
            }
        }

        public bool IsEnum => Parameter != null
                       && Parameter.Schema.Enum.Count > 0;
        public string DefaultValue { get; set; }
        public string Description { get; set; }
        public bool Optional { get; set; }
        public bool NullCheck => Type.Equals("string", System.StringComparison.OrdinalIgnoreCase) && Parameter.Required;
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsRouteParameter => Parameter.In == ParameterLocation.Path;
        public bool IsLast { get; set; }
        public OpenApiParameter Parameter { get; }
        public bool IsContent { get; internal set; }
    }
}