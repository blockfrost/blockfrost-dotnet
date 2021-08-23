using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Blockfrost.Api.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PaginationTestMethodAttribute : TestMethodAttribute, ITestDataSource
    {
        private readonly int _count;
        private readonly int _page;
        private readonly ESortOrder _sort;
        private readonly int _expected;

        public PaginationTestMethodAttribute(int count, int page, ESortOrder sort, int expected)
        {
            _count = count;
            _page = page;
            _sort = sort;
            _expected = expected;
        }
        public IEnumerable<object[]> GetData(MethodInfo info)
        {
            Type[] parameters = info.GetParameters().Select(p => p.ParameterType).ToArray();

            if(parameters.Length == 4)
            {
                return new[] { new object[] { _count, _page, _sort, _expected } };
            }

            throw new NotSupportedException($"Method signature on PaginationTestMethod '{info.Name}' is not supported.");
        }
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return $"Pagination_Count_{_count}_Page_{_page}_Sort_{_sort}_Returns_{_expected}";
        }
    }
    /// <summary>
    /// An extension to the [EnvironmentAwareTestMethod] attribute. 
    /// If the current envronment matches the name given in the constructor, the test method will be skipped
    /// </summary>
    public class IntegrationTestMethodAttribute : EnvironmentAwareTestMethodAttribute
    {
        private readonly string _environmentToIgnore;

        public IntegrationTestMethodAttribute(string environmentToIgnore)
        {
            _environmentToIgnore = environmentToIgnore;
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            return ExecuteOrInconclusive(testMethod, _environmentToIgnore, exclusive: false);
        }
    }
    public class EnvironmentOnlyTestMethodAttribute : EnvironmentAwareTestMethodAttribute
    {
        public EnvironmentOnlyTestMethodAttribute(string environment)
        {
            Environment = environment;
        }

        public string Environment { get; }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            return ExecuteOrInconclusive(testMethod, Environment);
        }
    }

    public class DevelopmentOnlyTestMethodAttribute : EnvironmentOnlyTestMethodAttribute
    {
        public DevelopmentOnlyTestMethodAttribute() : base(Environments.Development)
        {
        }
    }

    public class StagingOnlyTestMethodAttribute : EnvironmentOnlyTestMethodAttribute
    {
        public StagingOnlyTestMethodAttribute() : base(Environments.Staging)
        {
        }
    }

    public class ProductionOnlyTestMethodAttribute : EnvironmentOnlyTestMethodAttribute
    {
        public ProductionOnlyTestMethodAttribute() : base(Environments.Production)
        {
        }
    }
}