using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    internal class SchemaComponentContext
    {
        private OpenApiDocument _docs;
        private KeyValuePair<string, OpenApiSchema> _item;

        public SchemaComponentContext(OpenApiDocument docs, KeyValuePair<string, OpenApiSchema> item)
        {
            _docs = docs;
            _item = item;
        }
    }
}