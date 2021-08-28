// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Reflection;
using System.Text;

namespace Blockfrost.Api.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendQueryParameter(this StringBuilder builder, string name, object value)
        {
            return builder
                .Append(Uri.EscapeDataString(name))
                .Append('=')
                .Append(Uri.EscapeDataString(ConvertToString(value, System.Globalization.CultureInfo.InvariantCulture)))
                .Append('&');
        }

        private static string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is Enum)
            {
                string name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        if (field.GetCustomAttribute(typeof(System.Runtime.Serialization.EnumMemberAttribute)) is System.Runtime.Serialization.EnumMemberAttribute attribute)
                        {
                            return attribute.Value ?? name;
                        }
                    }

                    string converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo), cultureInfo);
                    return converted ?? string.Empty;
                }
            }
            else if (value is bool boolean)
            {
                return Convert.ToString(boolean, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[] bytes)
            {
                return Convert.ToBase64String(bytes);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            string result = Convert.ToString(value, cultureInfo);
            return result ?? "";
        }
    }
}
