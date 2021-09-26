using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    internal class ResponseComponentContext : OpenApiContext
    {
        private KeyValuePair<string, OpenApiResponse> _item;

        public ResponseComponentContext(OpenApiDocument spec, KeyValuePair<string, OpenApiResponse> item) : base(spec)
        {
            _item = item;
        }
    }
}