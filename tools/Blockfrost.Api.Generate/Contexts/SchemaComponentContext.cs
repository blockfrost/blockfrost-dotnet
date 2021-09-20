using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    internal class SchemaComponentContext : OpenApiContext
    {
        private KeyValuePair<string, OpenApiSchema> _item;

        public SchemaComponentContext(OpenApiDocument spec, KeyValuePair<string, OpenApiSchema> item) : base(spec)
        {
            _item = item;
        }
    }
}