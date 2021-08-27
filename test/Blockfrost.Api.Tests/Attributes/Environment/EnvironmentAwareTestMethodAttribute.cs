using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{
    public abstract class EnvironmentAwareTestMethodAttribute : TestMethodAttribute
    {
        protected static readonly IConfiguration __cfg = new ConfigurationBuilder()
                            .AddJsonFile(Constants.APPSETTINGS_TEST_FILENAME)
                            .AddEnvironmentVariables()
                            .Build();

        public static string EnvironmentName => __cfg[Constants.ENV_ENVIRONMENT];

        protected static TestResult[] CreateInconclusiveResult(string message)
        {
            return new[] {
                new TestResult
                {
                    Outcome = UnitTestOutcome.Inconclusive,
                    TestFailureException = new AssertInconclusiveException(message)
                }
            };
        }

        public bool IsEnvironment(string name)
        {
            return string.Equals(EnvironmentName.Trim(), name.Trim(), System.StringComparison.CurrentCultureIgnoreCase);
        }

        public bool IsNotEnvironment(string name)
        {
            return !IsEnvironment(name);
        }

        /// <summary>
        /// Executes the test method if the environment matches the criteria. Otherwise an inconclusive test result is returned
        /// </summary>
        /// <param name="testMethod">The testMethod</param>
        /// <param name="environment">The environment</param>
        /// <param name="exclusive">If true, the test will only run on the given environment, otherwise the given environment will be ignored.</param>
        /// <returns></returns>
        protected TestResult[] ExecuteOrInconclusive(ITestMethod testMethod, string environment, bool exclusive = true)
        {
            var message = $"Test not executed due to environment restriction.";
            return ExecuteOrInconclusive(testMethod, environment, message, exclusive);
        }

        /// <summary>
        /// Executes the test method if the environment matches the criteria. Otherwise an inconclusive test result is returned
        /// </summary>
        /// <param name="testMethod">The testMethod</param>
        /// <param name="environment">The environment</param>
        /// <param name="message">Message that will be displayed in the test result</param>
        /// <param name="exclusive">If true, the test will only run on the given environment</param>
        /// <returns></returns>
        protected TestResult[] ExecuteOrInconclusive(ITestMethod testMethod, string environment, string message, bool exclusive = true)
        {
            if (IsEnvironment(environment) == exclusive) return base.Execute(testMethod);
            return CreateInconclusiveResult(message);
        }
    }
}