using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{

    public class GetAttribute : Attribute 
    {
        public GetAttribute(string route)
        {
        }
    }

    public class MethodContext
    {
        public ServiceOperationContext Context;
        public OperationType HttpMethod { get; set; }
        public OpenApiOperation Current { get; set; }
        public List<ParameterContext> Parameters { get; private set; }
        public string ReturnType => TemplateHelper.GetReturnType(Context.Route, Schema);
        public string MethodName => GetMethodName();
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

        private OpenApiSchema EmptySchema()
        {
            return new OpenApiSchema() { Type = "object" };
        }

        private string GetMethodName()
        {
            var pathSegments = Regex.Matches(Context.Route, "(\\w+)", RegexOptions.IgnoreCase).Select(s => s.Value).ToList();
            var pathParams = Current.Parameters.Where(p => p.In == ParameterLocation.Path).Select(p => p.Name).ToList();
            var serviceName = Context.ServiceContext.ServiceName;
            var groupName = Context.ServiceContext.GroupName;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(HttpMethod);

            foreach (var item in pathSegments)
            {
                if (pathParams.Any(p => p.Equals(item, StringComparison.OrdinalIgnoreCase))) continue;
                if (groupName.Equals(item, StringComparison.OrdinalIgnoreCase)) continue;
                if (serviceName.Equals(item, StringComparison.OrdinalIgnoreCase)) continue;
                stringBuilder.Append(TemplateHelper.PascalCase(item));
            }

            return stringBuilder.ToString();
        }

        public MethodContext(ServiceOperationContext serviceOperationContext, OperationType type, OpenApiOperation operation)
        {
            Context = serviceOperationContext;
            HttpMethod = type;
            Current = operation;
            Parameters = Current.Parameters.Select(p => new ParameterContext(p)).ToList();
            if (Parameters.Count > 0)
            {
                Parameters.Last().IsLast = true;
            }
        }

        public override string ToString()
        {
            return MethodName;
        }
    }
}
