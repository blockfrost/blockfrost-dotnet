using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{

    public class HttpAttributeContext : OpenApiContext
    {
        private OperationType _item;

        public HttpAttributeContext(OpenApiDocument spec, OperationType item, List<KeyValuePair<string,string>> parameters) : base(spec)
        {
            _item = item;
            Parameters = parameters.Select(kvp => new ParameterContext(kvp)).ToList();
            Parameters.Last().IsLast = true;
        }

        public List<ParameterContext> Parameters { get; set; }
        public string HttpMethod => _item.ToString();
    }
}