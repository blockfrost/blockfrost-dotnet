using System;
using System.Text;
using Blockfrost.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Extensions
{
    [TestClass]
    [TestCategory(nameof(Blockfrost.Api))]
    [TestCategory(nameof(Blockfrost.Api.Tests.Extensions))]
    public class StringBuilderExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_Is_Null_Throws()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendQueryParameter(null, "value");
        }

        [TestMethod]
        public void Name_Value_Is_Not_Null_Or_Empty_Does_Not_Throw()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendQueryParameter("name", "value");
            Assert.AreEqual("name=value&", stringBuilder.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_Value_Is_Null_Throws()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendQueryParameter(null, null);
        }

        [TestMethod]
        public void Value_Is_Null_Does_Not_Throw()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendQueryParameter("name", null);
            Assert.AreEqual("name=&", stringBuilder.ToString());
        }
    }
}