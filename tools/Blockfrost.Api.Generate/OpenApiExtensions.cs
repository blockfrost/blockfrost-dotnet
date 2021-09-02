using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public static class OpenApiExtensions
    {
        public static List<KeyValuePair<string, OpenApiSchema>> SchemasWhere(this OpenApiDocument docs, Func<KeyValuePair<string, OpenApiResponse>, bool> isSuccess)
        {
            return docs.Paths.SelectMany(
                            path => path.Value.Operations.SelectMany(
                                http => http.Value.Responses.Where(isSuccess).SelectMany(
                                    resp => resp.Value.Content.Select(
                                        cont =>
                                        {
                                            var @ref = cont.Value.Schema.Reference;
                                            if (@ref == null)
                                            {
                                                return new KeyValuePair<string, OpenApiSchema>(path.Key, cont.Value.Schema);
                                            }
                                            else
                                            {
                                                var name = @ref.Id.Split("/").Last();
                                                var schema = (OpenApiSchema)docs.ResolveReference(@ref);
                                                return new KeyValuePair<string, OpenApiSchema>(@ref.Id, schema);
                                            }
                                        })))).ToList();
        }
        public static bool IsErrorStatusCode(this KeyValuePair<string, OpenApiResponse> response)
        {
            return !response.IsSuccessStatusCode();
        }
        public static bool IsSuccessStatusCode(this KeyValuePair<string, OpenApiResponse> response)
        {
            return response.Key.StartsWith("2");
        }
    }
}
