// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{
    [TestClass]
    public class PermuteVectorTestMethodAttributeTests : AVectorTestMethodAttributeTest
    {

        //[TestMethod]
        [DataRow(null, "")]
        public void Init(TestVector vector, string fileName)
        {
            var m = new PermuteVetorTestMethodAttribute(V_01, ALL_SUPPORTED_FILENAMES, '\'');
            Assert.IsNotNull(m);
            var method = typeof(VectorTestMethodAttributeTests).GetMethod(nameof(Init));
            var data = m.GetData(method);
            Assert.IsNotNull(data);
            foreach (object[] item in data)
            {
                string name = m.GetDisplayName(method, item);
                Assert.IsNotNull(name);
            }
        }

        //[PermuteVetorTestMethod(V_01, ALL_SUPPORTED_FILENAMES)]
        //public void Loads_Vector_And_Returns_FileName(TestVector vector, string fileName)
        //{
        //    Assert.IsNotNull(fileName);
        //    Assert.IsTrue(vector.GetFileInfo(fileName).Exists);
        //}
    }
}
