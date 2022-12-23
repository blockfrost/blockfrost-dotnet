using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Attributes.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class UserInputAttribute : DataRowAttribute, ITestDataSource
    {
        public UserInputAttribute(string format, params string[] args) : this(string.Format(CultureInfo.InvariantCulture, format, args)) 
        {
        }

        public UserInputAttribute(string input) : base(input.Split(" "))
        {
        }

        public new IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            try
            {
                var testMethod = methodInfo.GetCustomAttribute<CommandTestMethodAttribute>();

                var arguments = new List<object>
                {
                    testMethod.CommandType
                };

                arguments.AddRange(Data);

                var obj = new List<object[]>
                {
                    arguments.ToArray()
                };
                return obj;
            }
            catch (Exception)
            {
                var arguments = new List<object>(Data);
                return new List<object[]>
                {
                    arguments.ToArray()
                };
            }
        }

        public new string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            try
            {
                var commandType = (Type)data[0];
                string[] input = (string[])data[1];
                return $"{commandType.Name} '{string.Join(' ', input)}'";
            }
            catch (Exception)
            {
                return base.GetDisplayName(methodInfo, data);
            }
        }
    }
}
