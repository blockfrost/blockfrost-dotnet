using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests.Runtime
{
    public class BlockfrostTests
    {
        [SetUp]
        public void Setup()
        {
            var blocks = new BlockfrostService();
        }

        [TearDown]
        public void Teardown()
        {
        }

        [UnityTest]
        public IEnumerator TestMethod_TestingHow_TestResult()
        {
            // Arrange

            // Act
            yield return null;

            // Assert
            Assert.AreEqual(1, 1);
        }
    }
}