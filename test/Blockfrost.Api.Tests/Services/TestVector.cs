using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using Blockfrost.Api.Utils;
using System.Text.Json;

namespace Blockfrost.Api.Tests
{
    public class TestVector : ITestVector
    {
        public const string V_01 = "01";
        public const string TX_DRAFT = "tx.draft";
        public const string TX_DRAFT_RAW = "tx.draft.raw";
        public const string TX_SIGNED = "tx.signed";
        public const string TX_SIGNED_RAW = "tx.signed.raw";
        public const string SUPPORTED_FILENAMES = TX_DRAFT + "," + TX_DRAFT_RAW + "," + TX_SIGNED + "," + TX_SIGNED_RAW;

        /// <summary>
        /// Valid Tx (1 Ada)
        /// </summary>
        public const string V01 = "01";

        /// <summary>
        /// Valid Tx (minFee)
        /// </summary>
        public const string V02 = "02";

        /// <summary>
        /// Invalid CBOR (Blake2b512 digest)
        /// </summary>
        public const string V81 = "81";

        /// <summary>
        /// Invalid CBOR (Array Length > Map Length)
        /// </summary>
        public const string V82 = "82";

        /// <summary>
        /// Invalid Tx (Spent UTxO)
        /// </summary>
        public const string V91 = "93";

        private static ProtocolParameters __protocol { get; set; } = JsonSerializer.Deserialize<ProtocolParameters>(File.ReadAllText(Path.Combine(__testProjectRootDir, Constants.TEST_VECTOR_ROOT_DIRNAME, Constants.PROTOCOL_PARAMETERS_FILENAME)));

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

        public static string DummyHash = BitConverter.ToString(Blake2Fast.Blake2b.ComputeHash(32, new byte[] { 0x00 })).Replace("-","").ToLower();


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

        /// <summary>
        /// Calculates the fee for a given transaction
        /// </summary>
        /// <param name="cborHex"></param>
        /// <returns></returns>
        public uint CalculateMinFee(byte[] cborRaw)
        {            
            return (uint)(__protocol.TxFeeFixed + cborRaw.Length * __protocol.TxFeePerByte);
        }
    }
}