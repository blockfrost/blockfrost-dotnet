using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlebarsDotNet;

namespace Blockfrost.Api.Generate
{
    internal partial class Program
    {
        internal static string Source { get; set; }
        internal static DirectoryInfo TemplateDir { get; set; }
        internal static DirectoryInfo OutputDir { get; set; }
        internal static char[] GeneratorSwitch { get; set; } = "smav".ToCharArray();
        internal static string[] PreservationFilters { get; set; } = Array.Empty<string>();
        internal static string[] PurgeFilters { get; set; } = new[] { "*.generated*" };

        internal static bool ShouldWrite(char flag)
        {
            return GeneratorSwitch.Contains(flag);
        }
        
        internal static async Task Main(string[] args)
        {
            try
            {
                var context = await SetupEnvironment(args);
                
                PurgeFiles();

                Console.WriteLine("Generating blockfrost-dotnet boilerplate...");

                await WriteVarious(context);
                await WriteAttributes(context);
                await WriteModels(context);
                await WriteServices(context);

                Console.WriteLine("done!");
            }
            catch (KeyNotFoundException)
            {
                StringBuilder usage = new StringBuilder();
                usage.AppendLine("Blockfrost.Api.Generate.exe -s SOURCE -o OUTPUT_DIR -t TEMPLATE_DIR -g <[m]odels | [s]ervices | [a]ttributes | [v]arious>");
                usage.AppendLine("");
                usage.AppendLine("Parameters:");
                usage.Append("  -s").Append('\t').AppendLine("Local path or Uri of Blockfrost OpenApi Specification. Supported formats: [json, yaml]");
                usage.Append("  -t").Append('\t').AppendLine("Local template directory");
                usage.Append("  -o").Append('\t').AppendLine("Local output directory");
                usage.Append("  -g").Append('\t').AppendLine("Generator switch (default '-g smav' = all");
                usage.Append("  --purge [searchPattern, ...]").Append('\t').AppendLine("Delete all files matching one of the expressions (default '*.generated*')");
                usage.Append("  --preserve [searchPattern, ...]").Append('\t').AppendLine("Preserve all files matching one of the expressions (default '' = none");
                System.Console.WriteLine(usage.ToString());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error has occurred");
                Console.Error.WriteLine(ex);
            }
        }

        private static void PurgeFiles()
        {
            var purgeFiles = PurgeFilters.SelectMany(searchPattern => OutputDir.GetDirectories("*", SearchOption.AllDirectories).SelectMany(dir => dir.GetFiles(searchPattern, new EnumerationOptions() { MatchCasing = MatchCasing.CaseSensitive } ))).ToList();
            if (purgeFiles.Any())
            {
                Console.WriteLine();
                Console.WriteLine($"Purging [{string.Join(',', PurgeFilters)}]...");
                Console.WriteLine($"There are {purgeFiles.Count} files that will be deleted.");
                Console.WriteLine("Delete all files? [Y]es to all, [N]o to all, [I]nteractive");
                var key = Console.ReadKey().Key;

                foreach (var file in purgeFiles)
                {
                    if (key == ConsoleKey.N)
                    {
                        break;
                    }

                    if (key == ConsoleKey.I)
                    {
                        Console.WriteLine($"Delete '{file.FullName}'? (ENTER: confirm, OTHER: skip)");
                        if (Console.ReadKey().Key == ConsoleKey.Enter) file.Delete();
                    }

                    if (key == ConsoleKey.Y)
                    {
                        file.Delete();
                    }
                }
            }
        }

        private static void WriteInfo(OpenApiDocumentContext context)
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Blockfrost Specification: {context.Spec.Info.Version}");
            Console.WriteLine(info.ToString());
        }

        private static async Task<OpenApiDocumentContext> SetupEnvironment(string[] args)
        {
            var list = args.ToList();
            var opt = new Dictionary<string, string>();

            while (list.Any())
            {
                var hasOption = list.Count > 1 && !list[1].StartsWith("-");
                if (hasOption)
                {
                    opt.Add(list[0], list[1]);
                    list = list.Skip(2).ToList();
                } 
                else 
                {
                    opt.Add(list[0], null);
                    list = list.Skip(1).ToList();
                }
            }

            if (opt.ContainsKey("-g") && opt["-g"] != null)
            {
                GeneratorSwitch = opt["-g"].ToCharArray();
            }

            if (opt.ContainsKey("--preserve") && opt["--preserve"] != null)
            {
                PreservationFilters = opt["--preserve"].Split(",").Select(pattern => pattern.Trim()).ToArray();
            }

            if (opt.ContainsKey("--purge") && opt["--purge"] != null)
            {
                PurgeFilters = opt["--purge"].Split(",").Select(pattern => pattern.Trim()).ToArray();
            }

            OutputDir = new DirectoryInfo(opt["-o"]);
            if (!OutputDir.Exists)
            {
                OutputDir.Create();
            }

            TemplateDir = new DirectoryInfo(opt["-t"]);
            TemplateHelper.RegisterPartials(TemplateDir);

            Source = opt["-s"];

            var docs = await TemplateHelper.GetSpecsAsync(Source);
            var context = new OpenApiDocumentContext(OutputDir, docs);
            TemplateHelper.RegisterHelpers();
            WriteInfo(context);
            return context;
        }

        private static async Task WriteVarious(OpenApiDocumentContext context)
        {
            if (!ShouldWrite('v')) return;

            await WriteFile(context.ServiceExtension, "BlockfrostServiceExtensions.hbr", "Extensions", "BlockfrostServiceExtensions.cs");
            await WriteFile(null, "StringBuilderExtensions.hbr", "Extensions", "StringBuilderExtensions.cs");

            await WriteFile(null, "BlockfrostHashCode.hbr", "Utils", "BlockfrostHashCode.cs");

            await WriteFile(null, "Enums.hbr",  "Models", "Enums.cs");
            await WriteFile(null, "ApiException.hbr",  "Models", "Http", "ApiException.cs");
            await WriteFile(null, "HttpErrorResponse.hbr",  "Models", "Http", "HttpErrorResponse.cs");

            await WriteFile(null, "IBlockfrostService.hbr", "Services", "IBlockfrostService.cs");
            await WriteFile(null, "ABlockfrostService.hbr",  "Services", "ABlockfrostService.cs");
            Console.WriteLine();
        }

        private static async Task WriteServices(OpenApiDocumentContext context)
        {
            if (!ShouldWrite('s')) return;

            foreach (var serviceContext in context.Services)
            {
                await WriteFile(serviceContext, "service_interface.hbr", "Services", $"I{TemplateHelper.PascalCase(serviceContext.ServiceName)}Service.cs");
                await WriteFile(serviceContext, "service.hbr", "Services", serviceContext.GroupName, $"{TemplateHelper.PascalCase(serviceContext.ServiceName)}Service.cs");
            }
            Console.WriteLine();
        }

        private static async Task WriteModels(OpenApiDocumentContext context)
        {
            if (!ShouldWrite('m')) return;

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
            Console.WriteLine();
        }

        private static async Task WriteAttributes(OpenApiDocumentContext context)
        {
            if (!ShouldWrite('a')) return;

            foreach (var attributeContext in context.HttpAttributes)
            {
                await WriteFile(attributeContext, "httpAtts.hbr",  "Http", $"{TemplateHelper.PascalCase(attributeContext.HttpMethod)}Attribute.cs");
            }
            Console.WriteLine();
        }

        internal static async Task WriteFile(object data, string templateFileName, params string[] filepath)
        {
            var file = new FileInfo(Path.Combine(OutputDir.FullName, Path.Combine(filepath)));

            if (!file.Directory.Exists)
            {
                Console.WriteLine($"Creating\t{file.Directory}");
                file.Directory.Create();
            }

            var preserveExisting = PreservationFilters.SelectMany(searchPattern => file.Directory.GetFiles(searchPattern)).Any(f => f.FullName.Equals(file.FullName));

            if (file.Exists && preserveExisting)
            {
                var fullname = file.FullName;
                var ix = fullname.LastIndexOf('.');
                Console.WriteLine($"Preserving\t{file.FullName}");
                await WriteFile(data, templateFileName, fullname.Insert(ix, ".generated"));
                return;
            }

            using var fi = file.CreateText();
            var template = Handlebars.Compile(File.ReadAllText(Path.Combine(TemplateDir.FullName, templateFileName)));
            var bytes = fi.Encoding.GetBytes(template(data));
            
            if (file.Exists)
            {
                Console.WriteLine($"Overwriting\t{file.FullName}");
            } 
            else
            {
                Console.WriteLine($"Writing   \t{file.FullName}");
            }
            
            await fi.WriteLineAsync(Encoding.UTF8.GetString(bytes));
            await fi.FlushAsync();
            fi.Close();
        }
    }
}
