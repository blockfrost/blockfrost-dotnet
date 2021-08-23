using System.IO;

namespace Blockfrost.Api.Tests
{
    public interface ITestVector
    {
        byte[] GetFileBytes(string filename);
        FileInfo GetFileInfo(string filename);
        string GetFileText(string filename);
    }
}