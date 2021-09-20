using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public abstract class OpenApiContext
    {
        public OpenApiDocument Spec { get; private set; }
        public OpenApiContext(OpenApiDocument spec)
        {
            Spec = spec;
        }
    }
}
