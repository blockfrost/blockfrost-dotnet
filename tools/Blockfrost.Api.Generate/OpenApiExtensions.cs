using System;
using System.Collections.Generic;
using System.Linq;
using Blockfrost.Api.Generate.Contexts;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public static class OpenApiExtensions
    {
        public static bool IsContentType(this IOpenApiAny any, string contentType) => any switch
        {
            OpenApiString str => str.Value.Equals(contentType, System.StringComparison.OrdinalIgnoreCase),
            _ => false,
        }; 

        public static bool HasContentType(this OpenApiParameter parameter, string contentType)
        {
            if (parameter == null) return false;
            if (parameter.Schema == null) return false;
            if (parameter.Schema.Enum == null) return false;
            return parameter.Schema.Enum.Any(e => e.IsContentType(contentType));
        }

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
                                                return new KeyValuePair<string, OpenApiSchema>(path.Key,
                                                                                               cont.Value.Schema);
                                            }
                                            else
                                            {
                                                var name = @ref.Id.Split("/").Last();
                                                var schema = (OpenApiSchema)docs.ResolveReference(@ref);
                                                return new KeyValuePair<string, OpenApiSchema>(@ref.Id,
                                                                                               schema);
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

        public static string GetReturnType(this OpenApiDocument doc, ServiceOperationContext serviceOperationContext, OpenApiOperation operation)
        {
            try
            {
                var schema = doc.SchemasWhere(r => r.IsSuccessStatusCode());
                var successResponseSchema = operation.Responses.First(r => r.Key.StartsWith("2")).Value.Content.First().Value.Schema;
                ModelContext m = new ModelContext(doc, new KeyValuePair<string, OpenApiSchema>(serviceOperationContext.Route, successResponseSchema));
                return m.BaseType;
            }
            catch (Exception)
            {
                return "object";
            }
        }
    }
}
