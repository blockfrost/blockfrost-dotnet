using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

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
            FileInfo vectorFile = GetFileInfo(filename);
            if (!vectorFile.Exists) throw new FileNotFoundException(vectorFile.FullName);
            return File.ReadAllText(vectorFile.FullName);
        }

        public FileInfo GetFileInfo(string filename)
        {
            var vectorFile = new FileInfo(Path.Combine(ProjectDir.FullName, "dat", _vectorId, filename));
            return vectorFile;
        }

        private static DirectoryInfo ProjectDir
        {
            get
            {
                var projectDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory) // output directory
                                .Parent  // Debug / Release
                                .Parent  // bin
                                .Parent; // Blockfrost.Api.Tests
                return projectDir;
            }
        }

        public byte[] GetFileBytes(string filename)
        {
            FileInfo vectorFile = GetFileInfo(filename);
            if (!vectorFile.Exists) throw new FileNotFoundException(vectorFile.FullName);
            return File.ReadAllBytes(vectorFile.FullName);
        }
    }
}