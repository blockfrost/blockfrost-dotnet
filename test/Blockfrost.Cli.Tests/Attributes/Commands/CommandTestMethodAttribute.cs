using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Cli.Tests.Attributes.Commands
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandTestMethodAttribute : TestMethodAttribute
    {
        public Type CommandType { get; init; }

        public CommandTestMethodAttribute(Type type)
        {
            CommandType = type;
        }
    }
}
