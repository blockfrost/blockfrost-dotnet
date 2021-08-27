using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Blockfrost.Api.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PermuteVetorTestMethodAttribute : TestMethodAttribute, ITestDataSource
    {
        private readonly string _vectorId;
        private Dictionary<string, VectorTestMethodAttribute> testVectorAtts;

        public PermuteVetorTestMethodAttribute(string vectorId, string fileNames, char separator = '\'')
        {
            _vectorId = vectorId;
            testVectorAtts = fileNames.Split(separator).ToDictionary(filename => filename, filename => new VectorTestMethodAttribute(_vectorId, filename));
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var testResults = Array.Empty<TestResult>();
            foreach (var attribute in testVectorAtts.Values)
            {
                foreach (var result in attribute.Execute(testMethod))
                {
                    testResults.Append(result);
                }
            }
            return testResults;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var data = Array.Empty<object[]>();
            foreach (var attribute in testVectorAtts.Values)
            {
                foreach (var result in attribute.GetData(methodInfo))
                {
                    data.Append(result);
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
