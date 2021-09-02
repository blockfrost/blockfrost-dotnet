using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class ParameterContext
    {
        private KeyValuePair<string, string> _context;

        public ParameterContext(OpenApiParameter parameter)
        {
            _context = new KeyValuePair<string, string>(TemplateHelper.GetDataType(parameter.Schema), parameter.Name);
            Parameter = parameter;
        }

        public ParameterContext(KeyValuePair<string, string> kvp)
        {
            _context = kvp;
        }
        public bool HasDefault => Parameter != null && Parameter.Schema.Default.AnyType != Microsoft.OpenApi.Any.AnyType.Null;
        public string DefaultValue => Parameter?.Schema.Default.ToString();
        public string Type => _context.Key;
        public string Name => _context.Value;
        public bool IsLast { get; set; }
        public OpenApiParameter Parameter { get; }
    }

    public class HttpAttributeContext
    {
        private readonly OpenApiDocument _docs;
        private OperationType _item;
        public List<ParameterContext> Parameters { get; set; }

        public HttpAttributeContext(OpenApiDocument docs, OperationType item, List<KeyValuePair<string,string>> parameters)
        {
            _docs = docs;
            _item = item;
            Parameters = parameters.Select(kvp => new ParameterContext(kvp)).ToList();
            Parameters.Last().IsLast = true;
        }

        public string HttpMethod => _item.ToString();
    }
}