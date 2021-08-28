using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Attributes
{

    /// <summary>
    /// Marks a method as VectorTest disabling testruns on <see cref="Environments.Staging"/> and <see cref="Environments.Production"/> Multiple method signatures are supported:
    /// <para>
    /// <code><see cref="void"/> MethodName(<see cref="string"/> vectorId, <see cref="string"/> fileName);</code>
    /// <code><see cref="void"/> MethodName(<see cref="TestVector"/> testVevtor, <see cref="string"/> fileName);</code>
    /// <code><see cref="void"/> MethodName(<see cref="string"/> fileContentAsString);</code>
    /// <code><see cref="void"/> MethodName(<see cref="byte"/>[] fileContentAsByteArray);</code>
    /// <code><see cref="void"/> MethodName(<see cref="FileInfo"/> fileInfoOnly);</code>
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class VectorTestMethodAttribute : DevelopmentOnlyTestMethodAttribute, ITestDataSource, ITestVector
    {
        private readonly string _vectorId;
        private readonly TestVector _testVector;
        private readonly string _fileName;

        /// <summary>
        /// Initializes the TestVector
        /// </summary>
        /// <param name="vectorId"></param>
        /// <param name="fileName"></param>
        public VectorTestMethodAttribute(string vectorId, string fileName, bool allowNullVector = false)
        {
            _fileName = fileName;
            _vectorId = vectorId;
            try
            {
                _testVector = TestVector.Load(vectorId);
            }
            catch (Exception ex)
            {
                if (!allowNullVector)
                {
                    throw new InvalidOperationException($"TestVector '{_vectorId}' failed to load. Set {nameof(allowNullVector)} = true if this was intentional. See inner exception for details.", ex);
                }
            }
        }

        /// <summary>
        /// Initializes the TestVector
        /// </summary>
        /// <param name="vectorId"></param>
        /// <param name="fileName"></param>
        public VectorTestMethodAttribute(string vectorId, bool allowNullVector = false) : this(vectorId, string.Empty, allowNullVector)
        {
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            switch (parameters.Length)
            {
                case 1:
                    if (parameters[0] == typeof(string))
                    {
                        return new[] { new object[] { GetFileText(_fileName) } };
                    }

                    if (parameters[0] == typeof(byte[]))
                    {
                        return new[] { new object[] { GetFileBytes(_fileName) } };
                    }

                    if (parameters[0] == typeof(FileInfo))
                    {
                        return new[] { new object[] { GetFileInfo(_fileName) } };
                    }

                    break;
                case 2:
                    if (parameters[0] == typeof(string) && parameters[1] == typeof(string))
                    {
                        return new[] { new object[] { _vectorId, _fileName } };
                    }

                    if (parameters[0] == typeof(TestVector) && parameters[1] == typeof(string))
                    {
                        return new[] { new object[] { _testVector, _fileName } };
                    }

                    break;
                default:
                    throw new NotSupportedException($"Too " + (parameters.Length == 0 ? "few" : "many") + $" arguments on VectorTestMethod '{methodInfo.Name}'");
            }

            throw new NotSupportedException($"Method signature on VectorTestMethod '{methodInfo.Name}' is not supported.");
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return $"{_vectorId}: v <- {methodInfo.Name}('{_fileName}')";
        }

        public byte[] GetFileBytes(string filename)
        {
            return ((ITestVector)_testVector).GetFileBytes(filename);
        }

        public FileInfo GetFileInfo(string filename)
        {
            return ((ITestVector)_testVector).GetFileInfo(filename);
        }

        public string GetFileText(string filename)
        {
            return ((ITestVector)_testVector).GetFileText(filename);
        }
    }
}
