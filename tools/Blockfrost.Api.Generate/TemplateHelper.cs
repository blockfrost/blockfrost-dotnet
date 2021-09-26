using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Blockfrost.Api.Generate.Contexts;
using HandlebarsDotNet;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate
{
    public class TemplateHelper
    {
        public static void GetIsArrayBlockHelper(EncodedTextWriter output, BlockHelperOptions options, Context context, Arguments arguments)
        {
            switch (context.Value)
            {
                case SchemaNode node:
                    if (node.schema.Type.Equals("array", StringComparison.OrdinalIgnoreCase))
                    {
                        options.Template(output, context);
                    }
                    else
                    {
                        options.Inverse(output, context);
                    }
                    break;
                case ModelContext ctx:
                    if (ctx.IsArray)
                    {
                        options.Template(output, context);
                    }
                    else
                    {
                        options.Inverse(output, context);
                    }
                    break;
                default:
                    throw new HandlebarsException("Invalid context: {{#isArray}} supports OpenApiSchema as context");
            }
        }

        //@TODO REMOVE
        //public static string GetReturnType(string route, OpenApiSchema schema)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(PascalCase(route));

        //    if(schema.Type == null)
        //    {
        //        return "object";
        //    }

        //    if (schema.Type.Equals("array", StringComparison.OrdinalIgnoreCase))
        //    {
        //        sb.Insert(0, "ICollection<").Append("Item>");
        //    }
        //    else
        //    {
        //        sb.Append("Item");
        //    }
        //    return sb.ToString();
        //}

        internal static string GetDataType(OpenApiSchema schema)
        {
            return GetDataType(schema.Type);
        }

        public static string WriteSafe(object input)
        {
            if (input == null)
            {
                return null;
            }

            var env = input.ToString();
            env = env.Replace("\n", "");
            env = env.Replace("\r\n", "");
            env = env.Replace("\r", "");
            env = env.Replace("\t","");
            return env;
        }
        internal static void RegisterHelpers()
        {
            // register partials

            Handlebars.RegisterHelper("writeSafe", (writer, context, parameters) =>
            {
                writer.WriteSafeString(WriteSafe(parameters[0]));
            });
            Handlebars.RegisterHelper("curly", (writer, context, parameters) =>
            {
                writer.WriteSafeString($"{{{parameters[0]}}}");
            });

            Handlebars.RegisterHelper("packageName", (writer, context, parameters) => { writer.WriteSafeString("Blockfrost.Api"); });
            Handlebars.RegisterHelper("servicePackage", (writer, context, parameters) => { writer.WriteSafeString("Services"); });
            Handlebars.RegisterHelper("modelPackage", (writer, context, parameters) => { writer.WriteSafeString("Models"); });
            Handlebars.RegisterHelper("first", TemplateHelper.FirstBlockHelper);
            Handlebars.RegisterHelper("last", TemplateHelper.CamelCaseHelper);
            Handlebars.RegisterHelper("camel_case", TemplateHelper.CamelCaseHelper);
            Handlebars.RegisterHelper("pascal_case", TemplateHelper.PascalCaseHelper);
            Handlebars.RegisterHelper("lower_case", TemplateHelper.LowerCaseHelper);
            Handlebars.RegisterHelper("required_ctor_params", TemplateHelper.RequiredCtorParamsHelper);

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

            //Handlebars.RegisterHelper("isArray", TemplateHelper.IsArrayBlockHelper);
            Handlebars.RegisterHelper("isArray", TemplateHelper.GetIsArrayBlockHelper);
        }

        internal static void RegisterPartials(DirectoryInfo templateDir)
        {
            foreach (var item in templateDir.GetFiles("*.hbr"))
            {
                if (!item.Name.StartsWith("partial_", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Handlebars.RegisterTemplate(item.Name.Replace(".hbr", ""), File.ReadAllText(item.FullName));
            }
        }

        internal static async Task<OpenApiDocument> GetSpecsAsync(string path)
        {
            if (!File.Exists(path))
            {
                return await GetSpecsAsync(new Uri(path));
            }
            else
            {
                using var s = File.OpenRead(path);
                return await GetSpecsAsync(s);
            }
        }
        internal static async Task<OpenApiDocument> GetSpecsAsync(Stream content)
        {
            var read = new Microsoft.OpenApi.Readers.OpenApiStreamReader(new Microsoft.OpenApi.Readers.OpenApiReaderSettings());
            return await Task.FromResult(read.Read(content, out _));
        }
        internal static async Task<OpenApiDocument> GetSpecsAsync(Uri uri)
        {
            var spec = await new HttpClient().GetStreamAsync(uri);
            return await GetSpecsAsync(spec);
        }


        internal static void RequiredCtorParamsHelper(EncodedTextWriter output, Context context, Arguments arguments)
        {
            if(context.Value is SchemaNode node)
            {
                if (node.vars == null) return;
                var sdict = node.vars.Where(v => v.required)
                    .Select(x => new Tuple<string,string,string>(x.dataTypeWithEnum, CamelCase(x.name), x.defaultValue == null ? string.Empty : " = " + x.defaultValue.ToString()));
                
                output.WriteSafeString(string.Join(", ", sdict.Select(v => $"{v.Item1} {v.Item2}{v.Item3}")));
            }
            
            else if(context.Value is ModelContext ctx)
            {
                output.WriteSafeString("/** todo **/");
            } else 
            {
                throw new NotSupportedException("not supported in the current context");
            }
        }

        public static void PascalCaseHelper(EncodedTextWriter output, Context context, Arguments arguments)
        {
            if (arguments.Length != 1)
            {
                throw new InvalidOperationException("pascal_case requires a single parameter");
            }
            else
            {
                output.WriteSafeString($"{PascalCase(arguments[0])}");
            }
        }
        public static void LowerCaseHelper(EncodedTextWriter output, Context context, Arguments arguments)
        {
            if (arguments.Length != 1)
            {
                throw new InvalidOperationException("pascal_case requires a single parameter");
            }
            else
            {
                output.WriteSafeString($"{LowerCase(arguments[0])}");
            }
        }

        public static void CamelCaseHelper(EncodedTextWriter output, Context context, Arguments arguments)
        {
            if (arguments.Length != 1)
            {
                throw new InvalidOperationException("camel_case requires a single parameter");
            }
            else
            {
                output.WriteSafeString($"{TemplateHelper.CamelCase(arguments[0])}");
            }
        }


        public static void BlockHelper(EncodedTextWriter output, BlockHelperOptions options, Context context, Arguments arguments)
        {
            if (arguments.Length != 2)
            {
                throw new HandlebarsException("{{#isArray}} helper must have exactly two arguments");
            }

            var left = arguments.At<string>(0);
            var right = arguments[1] as string;
            if (left == right) options.Template(output, context);
            else options.Inverse(output, context);
        }

        public static void FirstBlockHelper(EncodedTextWriter output, BlockHelperOptions options, Context context, Arguments arguments)
        {
            if(context.Value is ServiceContext ctx)
            {
                var op = ctx.ops.FirstOrDefault();
                //op.Value.Values.First().First().Description
                options.Template(output, op);
            }else
            {
                options.Template(output, context);
            }
        }

        public static string CamelCase(object val)
        {
            var parts = _r.Matches(ToStringSafe(val)).Select(s => s.Value).ToArray();
            return string.Join("", UpperCaseFirstLetter(parts, 1));
        }

        private static string ToStringSafe(object val)
        {
            if(val == null)
            {
                val = "";    
            }
            
            var v = val.ToString();
            if (v.Equals("/")) v = "info";
            return v;
        }

        private static readonly Regex _r = new("([a-z0-9])+", RegexOptions.IgnoreCase);

        public static string PascalCase(object val)
        {
            var parts = _r.Matches(ToStringSafe(val)).Select(s => s.Value).ToArray();
            return string.Join("", UpperCaseFirstLetter(parts));
        }

        public static string LowerCase(object val)
        {
            var parts = _r.Matches(ToStringSafe(val)).Select(s => s.Value).ToArray();
            return string.Join("", parts).ToLower();
        }

        private static string[] UpperCaseFirstLetter(string[] parts, int start = 0)
        {
            for (int i = start; i < parts.Length; i++)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i][1..];
            }
            return parts;
        }

        internal static string GetDataType(string type)
        {
            switch (type)
            {
                case "string":
                    return "string";
                case "integer":
                    return "long";
                case "number":
                    return "double";
                case "boolean":
                    return "bool";
                case "bool":
                    return "bool";
                default:
                    break;
            }
            return "object";
        }

        public static async Task<OpenApiDocument> ReadSpecsAsync(string spec)
        {
            var encoding = Encoding.UTF8;
            if (Uri.IsWellFormedUriString(spec, UriKind.RelativeOrAbsolute))
            {
                var uri = new Uri(spec);
                spec = await new HttpClient().GetStringAsync(uri, CancellationToken.None);
            }

            if (Path.IsPathFullyQualified(spec))
            {
                spec = File.ReadAllText(spec, encoding);
            }
            
            using var stream = new MemoryStream(encoding.GetBytes(spec));
            var read = new Microsoft.OpenApi.Readers.OpenApiStreamReader(new Microsoft.OpenApi.Readers.OpenApiReaderSettings());
            var docs = read.Read(stream, out var diag);
            return docs;
        }
    }
}
