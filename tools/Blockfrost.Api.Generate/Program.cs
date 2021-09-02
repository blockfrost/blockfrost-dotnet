using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HandlebarsDotNet;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    internal partial class Program
    {
        internal static DirectoryInfo TemplateDir { get; } = new(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate\templates_simple\");

        internal static DirectoryInfo OutputDir { get; } = new(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate.Lib\");

        internal static async Task Main(string[] args)
        {
            if (!OutputDir.Exists)
            {
                OutputDir.Create();
            }

            foreach (var dir in OutputDir.GetDirectories())
            {
                foreach (var item in dir.GetFiles())
                {
                    item.Delete();
                }
            }

            var uri = new Uri("https://raw.githubusercontent.com/blockfrost/openapi/master/swagger.yaml");
            var docs = await TemplateHelper.GetSpecsAsync(uri);

            TemplateHelper.RegisterPartials(TemplateDir);
            TemplateHelper.RegisterHelpers();

            await WriteAttributes(docs);
            await WriteModels(docs);
            await WriteServices(docs);
        }

        private static async Task WriteServices(OpenApiDocument docs)
        {
            foreach (var tag in docs.Tags)
            {
                var ctx = new ServiceContext(docs, tag);
                await WriteServiceSimple(ctx);
            }
        }

        private static async Task WriteModels(OpenApiDocument docs)
        {
            foreach (var item in docs.Components.Responses)
            {
                var ctx = new ResponseComponentContext(docs, item);
                await WriteResponseSimple(ctx);
            }

            foreach (var item in docs.Components.Schemas)
            {
                var ctx = new SchemaComponentContext(docs, item);
                await WriteSchemaComponentSimple(ctx);
            }
            
            var successSchemas = docs.SchemasWhere(r => r.IsSuccessStatusCode());
            var errorSchemas = docs.SchemasWhere(r => r.IsErrorStatusCode());

            var distinctSchemas = successSchemas.Distinct().ToList();

            foreach (var item in distinctSchemas)
            {
                var ctx = new ModelContext(docs, item);
                await WriteModelSimple(ctx);
            }
        }

        private static async Task WriteAttributes(OpenApiDocument docs)
        {
            List<KeyValuePair<string, string>> parameters = new()
            {
                new("string", "route"),
                new("string", "version")
            };
            foreach (var item in docs.Paths.SelectMany(p => p.Value.Operations.Select(m => m.Key)))
            {
                HttpAttributeContext ctx = new(docs, item, parameters);
                await WriteOperationAttributesSimple(ctx);
            }
        }

        private static async Task WriteOperationAttributesSimple(HttpAttributeContext ctx)
        {
            await WriteFile(ctx, "httpAtts.hbr", "Http", $"{TemplateHelper.PascalCase(ctx.HttpMethod)}Attribute.cs");
        }

        private static async Task WriteServiceSimple(ServiceContext ctx)
        {
            Console.WriteLine($"Generating {ctx.GroupName}.{ctx.ServiceName}Service.cs with {ctx.ops.Count} paths");
            foreach (var op in ctx.ops)
            {
                Console.WriteLine($"{op.Key.Key} => has {op.Value.Count} paths");
            }
            await WriteFile(ctx, "service.hbr", "Services", ctx.GroupName, $"{TemplateHelper.PascalCase(ctx.ServiceName)}Service.cs");
        }

        private static async Task WriteModelSimple(ModelContext ctx)
        {
            await WriteFile(ctx, "model.hbr", "Models", $"{TemplateHelper.PascalCase(ctx.ClassName)}.cs");
        }

        internal static async Task WriteFile(object data, string templateFileName, params string[] filepath)
        {
            var template = CompileTemplate(templateFileName);
            string contents = template(data);
            string filename = Path.Combine(OutputDir.FullName, Path.Combine(filepath));
            var info = new FileInfo(filename);
            if (!info.Directory.Exists)
            {
                info.Directory.Create();
            }
            using var fi = info.CreateText();
            await fi.WriteLineAsync(contents);
        }

        private static HandlebarsTemplate<object, object> CompileTemplate(string templateName)
        {
            return Handlebars.Compile(File.ReadAllText(Path.Combine(TemplateDir.FullName, templateName)));
        }
    }
}
