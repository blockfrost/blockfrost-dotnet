using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Blockfrost.Api.Tests.Attributes
{
    [TestClass]
    public class VectorTestMethodAttributeTests
    {
        private const string V_01 = "01";
        private const string DOES_NOT_EXIST = "DOES_NOT_EXIST";

        private const string REFERENCE_DRAFT = "reference.draft";
        private const string REFERENCE_DRAFT_RAW = "reference.draft.raw";
        private const string REFERENCE_SIGNED = "reference.signed";
        private const string REFERENCE_SIGNED_RAW = "reference.signed.raw";

        private const string TX_DRAFT = "tx.draft";
        private const string TX_DRAFT_RAW = "tx.draft.raw";
        private const string TX_SIGNED = "tx.signed";
        private const string TX_SIGNED_RAW = "tx.signed.raw";

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
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                var attribute = new VectorTestMethodAttribute(vectorId, fileName, false);
            });
        }
    }
}
