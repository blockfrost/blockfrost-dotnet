using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    /// <summary>
    /// An extension to the [TestMethod] attribute. It walks the method and class hierarchy looking
    /// for an [IgnoreIf] attribute. If one or more are found, they are each evaluated, if the attribute
    /// returns `true`, evaluation is short-circuited, and the test method is skipped.
    /// </summary>
    public class IntegrationTestMethodAttribute : TestMethodAttribute
    {
        public IntegrationTestMethodAttribute(string env)
        {
            _ignoreEnvironment = env.Trim().ToLower();
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (_ignoreEnvironment != __cfg["NETCORE_ENVIRONMENT"])
                return base.Execute(testMethod);

            var message = $"Test not executed due to environment restriction.";
            return new[]
            {
                new TestResult
                {
                    Outcome = UnitTestOutcome.Inconclusive,
                    TestFailureException = new AssertInconclusiveException(message)
                }
            };
        }

        private static readonly IConfiguration __cfg = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        private readonly string _ignoreEnvironment;
    }
}
