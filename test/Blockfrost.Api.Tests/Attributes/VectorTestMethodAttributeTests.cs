using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{

    [TestClass]
    public class VectorTestMethodAttributeTests : AVectorTestMethodAttributeTest
    {
        [VectorTestMethod(V_01, TX_DRAFT)]
        [VectorTestMethod(V_01, TX_DRAFT_RAW)]
        [VectorTestMethod(V_01, TX_SIGNED)]
        [VectorTestMethod(V_01, TX_SIGNED_RAW)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT_RAW)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED_RAW)]
        public void Returns_String(string content)
        {
            Assert.IsNotNull(content);
        }

        [VectorTestMethod(V_01, TX_DRAFT)]
        [VectorTestMethod(V_01, TX_DRAFT_RAW)]
        [VectorTestMethod(V_01, TX_SIGNED)]
        [VectorTestMethod(V_01, TX_SIGNED_RAW)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT_RAW)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED_RAW)]
        public void Returns_ByteArray(byte[] content)
        {
            Assert.IsNotNull(content);
        }

        [VectorTestMethod(V_01, TX_DRAFT)]
        [VectorTestMethod(V_01, TX_DRAFT_RAW)]
        [VectorTestMethod(V_01, TX_SIGNED)]
        [VectorTestMethod(V_01, TX_SIGNED_RAW)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT_RAW)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED_RAW)]
        public void Returns_FileInfo(FileInfo info)
        {
            Assert.IsTrue(info.Exists);
        }

        [VectorTestMethod(V_01, TX_DRAFT)]
        [VectorTestMethod(V_01, TX_DRAFT_RAW)]
        [VectorTestMethod(V_01, TX_SIGNED)]
        [VectorTestMethod(V_01, TX_SIGNED_RAW)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT_RAW)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED_RAW)]
        public void Loads_Vector_And_Returns_FileName(TestVector vector, string fileName)
        {
            Assert.IsNotNull(fileName);
            Assert.IsTrue(vector.GetFileInfo(fileName).Exists);
        }

        [VectorTestMethod(V_01, TX_DRAFT)]
        [VectorTestMethod(V_01, TX_DRAFT_RAW)]
        [VectorTestMethod(V_01, TX_SIGNED)]
        [VectorTestMethod(V_01, TX_SIGNED_RAW)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT)]
        [VectorTestMethod(V_01, REFERENCE_DRAFT_RAW)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED)]
        [VectorTestMethod(V_01, REFERENCE_SIGNED_RAW)]
        public void Return_VectorId_And_FileName(string vectorId, string fileName)
        {
            Assert.IsNotNull(fileName);
            Assert.AreEqual(V_01, vectorId);
            Assert.IsTrue(TestVector.Load(vectorId).GetFileInfo(fileName).Exists);
        }

        [VectorTestMethod(DOES_NOT_EXIST, DOES_NOT_EXIST, allowNullVector: true)]
        public void AllowNullVector_Does_Not_Throw(string vectorId, string fileName)
        {
            Assert.AreEqual(DOES_NOT_EXIST, vectorId);
            Assert.AreEqual(DOES_NOT_EXIST, fileName);
        }

        [TestMethod]
        [DataRow(DOES_NOT_EXIST, DOES_NOT_EXIST)]
        public void DontAllowNullVector_Does_Throw(string vectorId, string fileName)
        {
            _ = Assert.ThrowsException<InvalidOperationException>(() =>
              {
                  var attribute = new VectorTestMethodAttribute(vectorId, fileName, false);
              });
        }
    }
}
