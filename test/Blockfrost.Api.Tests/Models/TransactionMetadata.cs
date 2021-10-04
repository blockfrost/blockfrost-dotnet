// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockfrost.Api.Tests.Models
{

    [TestClass]
    public class TransactionMetadata
    {
        [TestMethod]
        public void Serialize()
        {
            string json = @"[
  {
    ""label"": ""1967"",
    ""json_metadata"": {
      ""metadata"": ""https://nut.link/metadata.json"",
      ""hash"": ""6bf124f217d0e5a0a8adb1dbd8540e1334280d49ab861127868339f43b3948af""
    }
  },
  {
    ""label"": ""1968"",
    ""json_metadata"": {
      ""ADAUSD"": [
        {
          ""value"": ""0.10409800535729975"",
          ""source"": ""ergoOracles""
        }
      ]
    }
  }
]
";
            var item = JsonSerializer.Deserialize<Api.Models.TxContentMetadataResponseCollection>(json);
            Assert.AreEqual("1967", item.First().Label);
            Assert.AreEqual("6bf124f217d0e5a0a8adb1dbd8540e1334280d49ab861127868339f43b3948af", item.First().JsonMetadata.GetProperty("hash").GetString());
        }
    }
}
