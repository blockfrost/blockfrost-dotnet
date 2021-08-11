﻿using Blockfrost.Api.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Blockfrost.Api.Tests
{
    [TestClass]
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
