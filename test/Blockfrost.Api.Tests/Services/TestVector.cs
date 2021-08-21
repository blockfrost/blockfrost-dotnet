using System.IO;
using System;

namespace Blockfrost.Api.Tests
{
    public class TestVector
    {
        private string _vectorId;

        public TestVector(string vectorId1)
        {
            _vectorId = vectorId1;
        }

        internal static TestVector Load(string vectorId)
        {
            if (string.IsNullOrWhiteSpace(vectorId))
            {
                throw new System.ArgumentException($"'{nameof(vectorId)}' cannot be null or whitespace.", nameof(vectorId));
            }

            return new TestVector(vectorId);
        }

        public string GetFileText(string filename)
        {
            var projectDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) // output directory
                .Parent  // Debug / Release
                .Parent  // bin
                .Parent; // Blockfrost.Api.Tests
            var vectorFile = new FileInfo(Path.Combine(projectDir.FullName, "dat", _vectorId, filename));
            if (!vectorFile.Exists) throw new FileNotFoundException(vectorFile.FullName);
            return File.ReadAllText(vectorFile.FullName);
        }

    }
}