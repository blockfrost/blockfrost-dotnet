using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Blockfrost.Api.Generate.Contexts;
using HandlebarsDotNet;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    internal partial class Program
    {
        internal static string Source { get; set; }
        internal static DirectoryInfo TemplateDir { get; set; }
        internal static DirectoryInfo OutputDir { get; set; }

        internal static async Task Main(string[] args)
        {
            try
            {
                var context = await SetupEnvironment(args);

                Console.Write("Generating blockfrost-dotnet boilerplate...");

                await WriteScaffolding();
                await WriteAttributes(context);
                await WriteModels(context);
                await WriteServices(context);

                Console.WriteLine("done!");
            }
            catch (KeyNotFoundException)
            {
                StringBuilder usage = new StringBuilder();
                usage.AppendLine("Blockfrost.Api.Generate.exe -s SOURCE -o OUTPUT_DIR -t TEMPLATE_DIR");
                usage.AppendLine("");
                usage.AppendLine("Parameters:");
                usage.Append("  -s").Append('\t').AppendLine("Local path or Uri of Blockfrost OpenApi Specification. Supported formats: [json, yaml]");
                usage.Append("  -t").Append('\t').AppendLine("Local template directory");
                usage.Append("  -o").Append('\t').AppendLine("Local output directory");
                System.Console.WriteLine(usage.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occurred");
            }
        }

        private static void WriteInfo(OpenApiDocumentContext context)
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Blockfrost Specification: {context.Spec.Info.Version}");
            info.AppendLine($"");
            info.AppendLine($"Services: {context.Services.Count}");
            info.AppendLine($"Models: {context.Models.Count}");
            info.AppendLine($"Attributes: {context.HttpAttributes.Count}");
            Console.WriteLine(info.ToString());
        }

        private static async Task<OpenApiDocumentContext> SetupEnvironment(string[] args)
        {
            var list = args.ToList();
            var dict = new Dictionary<string, string>();

            while (list.Any())
            {
                dict.Add(list[0], list[1]);
                list = list.Skip(2).ToList();
            }

            Source = dict["-s"];
            TemplateDir = new DirectoryInfo(dict["-t"]);
            OutputDir = new DirectoryInfo(dict["-o"]);

            if (!OutputDir.Exists)
            {
                OutputDir.Create();
            }

            foreach (var file in OutputDir.GetDirectories().SelectMany(dir => dir.GetFiles()))
            {
                file.Delete();
            }

            TemplateHelper.RegisterPartials(TemplateDir);
            TemplateHelper.RegisterHelpers();
            var docs = await TemplateHelper.GetSpecsAsync(Source);
            var context = new OpenApiDocumentContext(docs);

            WriteInfo(context);
            return context;
        }

        private static async Task WriteScaffolding()
        {
            await WriteFile(null, "StringBuilderExtensions.hbr", "Extensions", "StringBuilderExtensions.cs");
            await WriteFile(null, "Enums.hbr", "Models", "Enums.cs");
            await WriteFile(null, "ApiException.hbr", "Models", "Http", "ApiException.cs");
            await WriteFile(null, "HttpErrorResponse.hbr", "Models", "Http", "HttpErrorResponse.cs");
            await WriteFile(null, "IBlockfrostService.hbr", "Services", "IBlockfrostService.cs");
            await WriteFile(null, "ABlockfrostService.hbr", "Services", "ABlockfrostService.cs");
        }

        private static async Task WriteServices(OpenApiDocumentContext context)
        {
            foreach (var serviceContext in context.Services)
            {
                await WriteFile(serviceContext, "service_interface.hbr", "Services", $"I{TemplateHelper.PascalCase(serviceContext.ServiceName)}Service.cs");
                await WriteFile(serviceContext, "service.hbr", "Services", serviceContext.GroupName, $"{TemplateHelper.PascalCase(serviceContext.ServiceName)}Service.cs");
            }
        }

        private static async Task WriteModels(OpenApiDocumentContext context)
        {
            // Write StringCollection for untyped responses
            await WriteFile(null, "StringCollection.hbr", "Models", "StringCollection.cs");

            // write Models
            foreach (var modelContext in context.Models)
            {
                await WriteFile(modelContext, "model.hbr", "Models", $"{TemplateHelper.PascalCase(modelContext.ClassName)}.cs");

                // write items if any
                if (modelContext.HasItem)
                {
                    await WriteFile(modelContext.ItemContext, "model.hbr", "Models", $"{TemplateHelper.PascalCase(modelContext.ItemContext.ClassName)}.cs");
                }
            }
        }

        private static async Task WriteAttributes(OpenApiDocumentContext context)
        {
            foreach (var attributeContext in context.HttpAttributes)
            {
                await WriteFile(attributeContext, "httpAtts.hbr", "Http", $"{TemplateHelper.PascalCase(attributeContext.HttpMethod)}Attribute.cs");
            }
        }

        internal static async Task WriteFile(object data, string templateFileName, params string[] filepath)
        {
            var template = Handlebars.Compile(File.ReadAllText(Path.Combine(TemplateDir.FullName, templateFileName)));

            var info = new FileInfo(Path.Combine(OutputDir.FullName, Path.Combine(filepath)));
            if (!info.Directory.Exists)
            {
                info.Directory.Create();
            }
            using var fi = info.CreateText();
            await fi.WriteLineAsync(template(data));
        }
    }
}
