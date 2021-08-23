using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockfrost.Api.Tests
{
    public class TestVector : ITestVector
    {
        private DirectoryInfo _vectorDir;
        private string _vectorId;
        public TestVector(string vectorId1)
        {
            _vectorId = vectorId1;
            _vectorDir = GetDirectoryInfo(__testProjectRootDir, Constants.TEST_VECTOR_ROOT_DIRNAME, _vectorId);
        }

        /// <summary>
        /// Returns true if the directory "${ProjectDir}/dat/VectorId" exists, otherwise false
        /// </summary>
        public bool Exists => _vectorDir.Exists;

        private static string __testProjectRootDir
        {
            get
            {
                var projectDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) // output directory
                                  .Parent  // Debug / Release
                                  .Parent  // bin
                                  .Parent; // Blockfrost.Api.Tests
                return projectDir.FullName;
            }
        }

        public static FileInfo GetFileInfo(params string[] segments)
        {
            FileInfo vectorFile = new FileInfo(Path.Combine(segments));
            return vectorFile;
        }

        public byte[] GetFileBytes(string filename)
        {
            FileInfo vectorFile = GetFileInfo(filename);
            if (!vectorFile.Exists) throw new FileNotFoundException(vectorFile.FullName);
            return File.ReadAllBytes(vectorFile.FullName);
        }

        public FileInfo GetFileInfo(string filename)
        {
            return GetFileInfo(_vectorDir.FullName, filename);
        }

        public string GetFileText(string filename)
        {
            FileInfo vectorFile = GetFileInfo(filename);
            if (!vectorFile.Exists) throw new FileNotFoundException(vectorFile.FullName);
            return File.ReadAllText(vectorFile.FullName);
        }

        internal static TestVector Load(string vectorId)
        {
            if (string.IsNullOrWhiteSpace(vectorId))
            {
                throw new System.ArgumentException($"'{nameof(vectorId)}' cannot be null or whitespace.", nameof(vectorId));
            }

            var vector = new TestVector(vectorId);
            if (!vector.Exists) throw new InvalidOperationException($"Could not load TestVector '{nameof(vectorId)}' because the path does not exist.");
            return vector;
        }

        private static DirectoryInfo GetDirectoryInfo(params string[] segments)
        {
            return new DirectoryInfo(Path.Combine(segments));
        }
    }
}