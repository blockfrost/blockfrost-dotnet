using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{
    /// <summary>
    /// An extension of the [TestClass] attribute. If applied to a class, any [TestMethod] attributes
    /// are automatically upgraded to [TestMethodWithIgnoreIfSupport].
    /// </summary>
    public class IntegrationTestClassAttribute : TestClassAttribute
    {
        public IntegrationTestClassAttribute(string ignoreEnvironment)
        {
            IgnoreEnvironment = ignoreEnvironment;
        }

        public string IgnoreEnvironment { get; }

        public override TestMethodAttribute GetTestMethodAttribute(TestMethodAttribute testMethodAttribute)
        {
            if (testMethodAttribute is IntegrationTestMethodAttribute)
            {
                return testMethodAttribute;
            }

            return new IntegrationTestMethodAttribute(IgnoreEnvironment);
        }
    }
}
