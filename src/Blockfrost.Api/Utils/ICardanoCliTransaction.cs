﻿// Copyright (c) 2021 FIVE BINARIES OÜ. blockfrost-dotnet is licensed under the Apache License Version 2.0. See LICENSE in the project root for license information.

namespace Blockfrost.Api.Utils
{
    public interface ICardanoCliTransaction
    {
        string CBORHex { get; set; }
        string Description { get; set; }
        string Type { get; set; }
    }
}