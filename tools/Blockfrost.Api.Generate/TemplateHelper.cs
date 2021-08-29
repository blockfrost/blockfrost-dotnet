using System;
using System.Text;

namespace Blockfrost.Api.Generate
{
    public class TemplateHelper
    {

        public static string CamelCase(object val)
        {
            var b = new StringBuilder(PascalCase(val));
            b[0] = char.ToLower(b[0], System.Globalization.CultureInfo.InvariantCulture);
            return b.ToString();
        }

        public static string PascalCase(object val)
        {
            string v1 = val.ToString();
            char[] value = v1.ToCharArray();
            var b = new StringBuilder();

            bool toUpper = true;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '_')
                {
                    toUpper = true;
                    continue;
                }
                else
                {
                    char v = toUpper ? char.ToUpper(value[i], System.Globalization.CultureInfo.InvariantCulture) : value[i];
                    _ = b.Append(v);
                }
                toUpper = false;
            }
            return b.ToString();
        }

        internal static string GetDataType(string type)
        {
            switch (type)
            {
                case "string":
                    return "string";
                case "integer":
                    return "integer";
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
    }
}
