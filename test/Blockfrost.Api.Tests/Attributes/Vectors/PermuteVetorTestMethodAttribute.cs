// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PermuteVetorTestMethodAttribute : TestMethodAttribute, ITestDataSource
    {
        private readonly string _vectorId;
        private readonly Dictionary<string, VectorTestMethodAttribute> _testVectorAtts;

        public PermuteVetorTestMethodAttribute(string vectorId, string fileNames, char separator = '\'')
        {
            _vectorId = vectorId;
            _testVectorAtts = fileNames.Split(separator).ToDictionary(filename => filename, filename => new VectorTestMethodAttribute(_vectorId, filename));
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var testResults = Array.Empty<TestResult>();
            foreach (var attribute in _testVectorAtts.Values)
            {
                foreach (var result in attribute.Execute(testMethod))
                {
                    _ = testResults.Append(result);
                }
            }

            return testResults;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            object[][] data = Array.Empty<object[]>();
            foreach (var attribute in _testVectorAtts.Values)
            {
                foreach (object[] result in attribute.GetData(methodInfo))
                {
                    _ = data.Append(result);
                }
            }

            return data;
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return "PermuteVectorTest";
        }
    }
}
