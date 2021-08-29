using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Blockfrost.Api.Generate
{
    internal class Program
    {
        internal static DirectoryInfo TemplateDir { get; } = new(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate\templates\");

        internal static DirectoryInfo OutputDir { get; } = new(@"C:\dev\tweakch\blockfrost-dotnet\tools\Blockfrost.Api.Generate\output\");

        internal static async Task Main(string[] args)
        {
            var spec = await new HttpClient().GetStreamAsync("https://raw.githubusercontent.com/blockfrost/openapi/master/swagger.yaml");
            var read = new Microsoft.OpenApi.Readers.OpenApiStreamReader(new Microsoft.OpenApi.Readers.OpenApiReaderSettings());
            var docs = read.Read(spec, out var diag);

            RegisterHandlebar();

            var data = new GeneratorContext(docs)
            {
                packageName = "Blockfrost.Api",
                modelPackage = "Models",
                servicePackage = "Services"
            };

            foreach (var model in data.models.Where(m => m.node.baseName == "account_addresses_assets"))
            {
                WriteModel(model);
            }

            WriteTest();
        }

        private static void WriteModel(SchemaContext data)
        {
            WriteFile(data, "model.hbr", $"{data.classname}.cs");
        }

        private static void WriteTest()
        {
            var data = new
            {
                title = "My new post",
                body = "This is my first post!"
            };

            WriteFile(data, "test.hbr", "test.html");
        }

        private static void RegisterHandlebar()
        {
            // register partials
            foreach (var item in TemplateDir.GetFiles("*.hbr"))
            {
                if (!item.Name.StartsWith("partial_", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Handlebars.RegisterTemplate(item.Name.Replace(".hbr", ""), File.ReadAllText(item.FullName));
            }

            Handlebars.RegisterHelper("camel_case", (writer, context, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new InvalidOperationException("camel_case requires a single parameter");
                }
                else
                {
                    writer.WriteSafeString($"{TemplateHelper.CamelCase(parameters[0])}");
                }
            });

            Handlebars.RegisterHelper("pascal_case", (writer, context, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new InvalidOperationException("pascal_case requires a single parameter");
                }
                else
                {
                    writer.WriteSafeString($"{TemplateHelper.PascalCase(parameters[0])}");
                }
            });

            Handlebars.RegisterHelper("required_ctor_params", (writer, context, parameters) =>
            {
                if(parameters.Length != 1)
                {
                    throw new InvalidOperationException("required_ctor_params requires a single parameter");
                }
                else
                {
                    var required = ((List<SchemaNode>)parameters[0]).Where(v => v.required);
                    var dict = required.ToDictionary(v => TemplateHelper.CamelCase(v.name), v => v.dataTypeWithEnum);
                    writer.WriteSafeString(string.Join(", ", dict.Select(v => $"{v.Value} {v.Key} = default")));
                }
            });

            Handlebars.RegisterHelper("is_array", (writer, context, parameters) =>
            {
                if (parameters.Length != 1)
                {
                    throw new InvalidOperationException("is_array requires a single parameter");
                }
                else
                {
                    writer.WriteSafeString($"{TemplateHelper.CamelCase(parameters[0])}");
                }
            });
        }

        internal static void WriteFile(object data, string templateFileName, string outputFileName)
        {
            var template = CompileTemplate(templateFileName);
            string contents = template(data);
            string filepath = Path.Combine(OutputDir.FullName, outputFileName);
            Console.WriteLine(filepath);
            File.WriteAllText(filepath, contents);
        }

        private static HandlebarsTemplate<object, object> CompileTemplate(string templateName)
        {
            return Handlebars.Compile(File.ReadAllText(Path.Combine(TemplateDir.FullName, templateName)));
        }
    }
}
