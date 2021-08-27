// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

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
