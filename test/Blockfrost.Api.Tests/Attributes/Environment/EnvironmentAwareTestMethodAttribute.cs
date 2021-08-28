// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{
    public abstract class EnvironmentAwareTestMethodAttribute : TestMethodAttribute
    {
        protected static readonly IConfiguration TestConfiguration = new ConfigurationBuilder()
                            .AddJsonFile(Constants.APPSETTINGS_TEST_FILENAME)
                            .AddEnvironmentVariables()
                            .Build();

        public static string EnvironmentName => TestConfiguration[Constants.ENV_ENVIRONMENT];

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

        public static bool IsEnvironment(string name)
        {
            return string.Equals(EnvironmentName.Trim(), name.Trim(), System.StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNotEnvironment(string name)
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
            string message = $"Test not executed due to environment restriction.";
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
            return IsEnvironment(environment) == exclusive ? base.Execute(testMethod) : CreateInconclusiveResult(message);
        }
    }
}
