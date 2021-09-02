using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    internal class ResponseComponentContext
    {
        private OpenApiDocument _docs;
        private KeyValuePair<string, OpenApiResponse> _item;

        public ResponseComponentContext(OpenApiDocument docs, KeyValuePair<string, OpenApiResponse> item)
        {
            _docs = docs;
            _item = item;
        }
    }
}