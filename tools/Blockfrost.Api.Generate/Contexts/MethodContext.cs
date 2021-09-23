using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{

    public class MethodContext
    {
        public MethodContext(ServiceOperationContext serviceOperationContext, OperationType type, OpenApiOperation operation)
        {
            Context = serviceOperationContext;
            HttpMethod = type;
            Current = operation;

            Parameters = Current.Parameters.Where(p => p.In.HasValue && (p.In.Value == ParameterLocation.Query || p.In.Value == ParameterLocation.Path)).Select(p => new ParameterContext(p)).ToList();

            HasQueryParameters = Parameters.Any(p => p.Parameter.In == ParameterLocation.Query);
            HasHeaderParameters = Parameters.Any(p => p.Parameter.In == ParameterLocation.Header);
            HasPathParameters = Parameters.Any(p => p.Parameter.In == ParameterLocation.Path);
            
            HasNullCheck = Parameters.Any(p => p.NullCheck);

            HasCborContent = Current.Parameters.Where(paramCtx => paramCtx.In == ParameterLocation.Header).Any(parameter => parameter.HasContentType("application/cbor"));
            HasJsonContent = Current.Parameters.Where(paramCtx => paramCtx.In == ParameterLocation.Header).Any(parameter => parameter.HasContentType("application/json"));

            if (Parameters.Count > 0)
            {
                Parameters.Last().IsLast = true;
            }

            var signature = new List<string>(Signature);
            if (signature.Count == 0)
            {
                signature.Add(Context.ServiceContext.ServiceName);
            }

            ReturnType = Context.ServiceContext.Spec.GetReturnType(serviceOperationContext, operation);
            ReturnModel = !(ReturnType == null || ReturnType.Equals("object") || ReturnType.Equals("string"));
            signature.Insert(0, HttpMethod.ToString());
            MethodName = string.Concat(signature.Distinct());
            
            if (HttpMethod == OperationType.Post)
            {
                var p = Parameters.FirstOrDefault();
                ReturnType = "string";
                ReturnModel = false;
                if (p == null)
                {
                    return;
                }

                p.Type = "System.IO.Stream";
                p.Name = "content";
                p.IsContent = true;
            }

        }
        public bool ReturnModel { get; set; }
        public bool HasNullCheck { get; set; }

        public ServiceOperationContext Context;
        public OperationType HttpMethod { get; set; }
        public OpenApiOperation Current { get; set; }
        public List<ParameterContext> Parameters { get; private set; }
        public bool IsRoot => Context.Route.Equals("/", StringComparison.OrdinalIgnoreCase);

        public string ReturnType { get; private set; }

        public string MethodName { get; private set; }

        public bool HasQueryParameters { get; set; }
        public bool HasPathParameters { get; set; }
        public bool HasHeaderParameters { get; set; }
        public bool HasNonHeaderParameters => HasPathParameters || HasQueryParameters;

        public string Description => Current.Description;
        public string Summary => Current.Summary;
        public string Returns => Current.Responses["200"].Description;
        public string ParameterList { get; set; }

        public OpenApiSchema Schema => GetSchema();

        private OpenApiSchema GetSchema()
        {
            var content = Current.Responses["200"].Content;
            return content.ContainsKey("application/json")
                ? content["application/json"].Schema
                : content.ContainsKey("application/cbor")
                ? content["application/cbor"].Schema
                : content.Any()
                ? content.First().Value.Schema
                : EmptySchema();
        }

        public bool HasCborContent { get; set; }
        public bool HasJsonContent { get; set; }
        public bool HasStreamContent => HasJsonContent || HasCborContent;

        private OpenApiSchema EmptySchema()
        {
            return new OpenApiSchema() { Type = "object" };
        }

        public string[] Signature
        {
            get
            {
                if (Context.Route.Equals("/"))
                {
                    return new[] { "ApiInfo" };
                }
                var pathSegments = Regex.Matches(Context.Route, "(\\w+)", RegexOptions.IgnoreCase).Select(s => s.Value).ToList();
                var pathParams = Current.Parameters.Where(p => p.In == ParameterLocation.Path).Select(p => p.Name).ToList();
                var serviceName = Context.ServiceContext.ServiceName;
                var groupName = Context.ServiceContext.GroupName;

                var signature = new List<string>();
                foreach (var item in pathSegments)
                {
                    if (pathParams.Any(p => p.Equals(item, StringComparison.OrdinalIgnoreCase))) continue;
                    if (groupName.Equals(item, StringComparison.OrdinalIgnoreCase)) continue;
                    if (serviceName.Equals(item, StringComparison.OrdinalIgnoreCase)) continue;
                    signature.Add(TemplateHelper.PascalCase(item));
                }

                return signature.ToArray();
            }
        }
        public string ModelName { get; set; }
        public bool IsStream { get; private set; }

        public override string ToString()
        {
            return MethodName;
        }
    }
}
