using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests
{
    /// <summary>
    /// An extension of the [TestClass] attribute. If applied to a class, any [TestMethod] attributes
    /// are automatically upgraded to [TestMethodWithIgnoreIfSupport].
    /// </summary>
    public class IgnoreAllIfAttribute : TestClassAttribute
    {
        public string IgnoreEnvironment { get; }

        public IgnoreAllIfAttribute(string ignoreEnvironment)
        {
            IgnoreEnvironment = ignoreEnvironment;
        }
        
        public override TestMethodAttribute GetTestMethodAttribute(TestMethodAttribute testMethodAttribute)
        {
            if (testMethodAttribute is TestMethodWithIgnoreIfSupportAttribute)
            {
                return testMethodAttribute;
            }
            return new TestMethodWithIgnoreIfSupportAttribute(IgnoreEnvironment);
        }
    }
}